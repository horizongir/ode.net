using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents a data object which is used to store triangle mesh data.
    /// </summary>
    public sealed class TriMeshData : IDisposable
    {
        readonly dTriMeshDataID id;
        IntPtr verticesData;
        IntPtr indicesData;
        IntPtr normalsData;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriMeshData"/> class.
        /// </summary>
        public TriMeshData()
        {
            id = NativeMethods.dGeomTriMeshDataCreate();
        }

        /// <summary>
        /// Builds the triangle mesh data object with single precision vertex data.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// represents the index of one of the vertices.
        /// </param>
        public void BuildSingle(float[] vertices, int[] indices)
        {
            BuildSingle(vertices, indices, null);
        }

        /// <summary>
        /// Builds the triangle mesh data object with single precision vertex data
        /// and pre-calculated normals.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// represents the index of one of the vertices.
        /// </param>
        /// <param name="normals">The array of pre-calculated normals.</param>
        public void BuildSingle(float[] vertices, int[] indices, dReal[] normals)
        {
            int vertexCount = vertices.Length / 3;
            int vertexStride = 3 * Marshal.SizeOf(typeof(float));
            int indexCount = indices.Length;
            int triStride = 3 * Marshal.SizeOf(typeof(int));
            StoreMeshData(vertices, indices, normals);
            if (normals != null)
            {
                NativeMethods.dGeomTriMeshDataBuildSingle1(
                    id, verticesData, vertexStride, vertexCount,
                    indicesData, indexCount, triStride, normalsData);
            }
            else
            {
                NativeMethods.dGeomTriMeshDataBuildSingle(
                id, verticesData, vertexStride, vertexCount,
                indicesData, indexCount, triStride);
            }
        }

        /// <summary>
        /// Builds the triangle mesh data object with double precision vertex data.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// represents the index of one of the vertices.
        /// </param>
        public void BuildDouble(double[] vertices, int[] indices)
        {
            BuildDouble(vertices, indices, null);
        }

        /// <summary>
        /// Builds the triangle mesh data object with double precision vertex data
        /// and pre-calculated normals.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// represents the index of one of the vertices.
        /// </param>
        /// <param name="normals">The array of pre-calculated normals.</param>
        public void BuildDouble(double[] vertices, int[] indices, dReal[] normals)
        {
            int vertexCount = vertices.Length / 3;
            int vertexStride = 3 * Marshal.SizeOf(typeof(double));
            int indexCount = indices.Length;
            int triStride = 3 * Marshal.SizeOf(typeof(int));
            StoreMeshData(vertices, indices, normals);
            if (normals != null)
            {
                NativeMethods.dGeomTriMeshDataBuildDouble1(
                    id, verticesData, vertexStride, vertexCount,
                    indicesData, indexCount, triStride, normalsData);
            }
            else
            {
                NativeMethods.dGeomTriMeshDataBuildDouble(
                id, verticesData, vertexStride, vertexCount,
                indicesData, indexCount, triStride);
            }
        }

        /// <summary>
        /// Builds the triangle mesh data object with vertex data.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// is an index into the vertices array.
        /// </param>
        public void BuildSimple(Vector3[] vertices, int[] indices)
        {
            BuildSimple(vertices, indices, null);
        }

        /// <summary>
        /// Builds the triangle mesh data object with vertex data and
        /// pre-calculated normals.
        /// </summary>
        /// <param name="vertices">The array of mesh vertices.</param>
        /// <param name="indices">
        /// The array of indices forming the triangle mesh. Each element in the array
        /// is an index into the vertices array.
        /// </param>
        /// <param name="normals">The array of pre-calculated normals.</param>
        public void BuildSimple(Vector3[] vertices, int[] indices, dReal[] normals)
        {
            StoreMeshData(vertices, indices, normals);
            if (normals != null)
            {
                NativeMethods.dGeomTriMeshDataBuildSimple1(
                    id, verticesData, vertices.Length,
                    indicesData, indices.Length, normalsData);
            }
            else
            {
                NativeMethods.dGeomTriMeshDataBuildSimple(
                    id, verticesData, vertices.Length,
                    indicesData, indices.Length);
            }
        }

        /// <summary>
        /// Preprocesses the trimesh data to remove unnecessary edges and vertices.
        /// </summary>
        public void Preprocess()
        {
            NativeMethods.dGeomTriMeshDataPreprocess(id);
        }

        private static void ReleaseDataStore(ref IntPtr storeHandle)
        {
            if (storeHandle != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(storeHandle);
            }

            storeHandle = IntPtr.Zero;
        }

        private void ReleaseDataStores()
        {
            ReleaseDataStore(ref verticesData);
            ReleaseDataStore(ref indicesData);
            ReleaseDataStore(ref normalsData);
        }

        private void StoreMeshData<TVertex>(TVertex[] vertices, int[] indices, dReal[] normals)
        {
            ReleaseDataStores();
            verticesData = Marshal.AllocHGlobal(vertices.Length * Marshal.SizeOf(typeof(TVertex)));
            indicesData = Marshal.AllocHGlobal(indices.Length * Marshal.SizeOf(typeof(int)));

            float[] floatVertices = vertices as float[];
            if (floatVertices != null) Marshal.Copy(floatVertices, 0, verticesData, vertices.Length);

            double[] doubleVertices = vertices as double[];
            if (doubleVertices != null) Marshal.Copy(doubleVertices, 0, verticesData, vertices.Length);

            Marshal.Copy(indices, 0, indicesData, indices.Length);
            if (normals != null)
            {
                normalsData = Marshal.AllocHGlobal(normals.Length * Marshal.SizeOf(typeof(int)));
                Marshal.Copy(normals, 0, normalsData, normals.Length);
            }
        }

        /// <summary>
        /// Destroys the triangle mesh data.
        /// </summary>
        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                ReleaseDataStores();
                id.Close();
            }
        }
    }
}
