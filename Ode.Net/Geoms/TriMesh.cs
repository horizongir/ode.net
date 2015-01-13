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
    public sealed class TriMesh : Geom
    {
        TriMeshData data;
        TriangleCallback callback;
        TriangleArrayCallback arrayCallback;
        TriangleRayCallback rayCallback;
        TriangleTriangleMergeCallback triangleMergeCallback;

        public TriMesh(TriMeshData data)
            : this(null, data)
        {
        }

        public TriMesh(Space space, TriMeshData data)
            : base(NativeMethods.dCreateTriMesh(space != null ? space.Id : dSpaceID.Null, data.Id, null, null, null))
        {
            this.data = data;
        }

        public TriMeshData Data
        {
            get { return data; }
            set
            {
                data = value;
                NativeMethods.dGeomTriMeshSetData(Id, value.Id);
            }
        }

        public int TriangleCount
        {
            get { return NativeMethods.dGeomTriMeshGetTriangleCount(Id); }
        }

        public TriangleCallback Callback
        {
            get { return callback; }
            set
            {
                if (value == null) NativeMethods.dGeomTriMeshSetCallback(Id, null);
                else NativeMethods.dGeomTriMeshSetCallback(Id, TriCallback);
                callback = value;
            }
        }

        public TriangleArrayCallback ArrayCallback
        {
            get { return arrayCallback; }
            set
            {
                if (value == null) NativeMethods.dGeomTriMeshSetArrayCallback(Id, null);
                else NativeMethods.dGeomTriMeshSetArrayCallback(Id, TriArrayCallback);
                arrayCallback = value;
            }
        }

        public TriangleRayCallback RayCallback
        {
            get { return rayCallback; }
            set
            {
                if (value == null) NativeMethods.dGeomTriMeshSetRayCallback(Id, null);
                else NativeMethods.dGeomTriMeshSetRayCallback(Id, TriRayCallback);
                rayCallback = value;
            }
        }

        public TriangleTriangleMergeCallback TriangleMergeCallback
        {
            get { return triangleMergeCallback; }
            set
            {
                if (value == null) NativeMethods.dGeomTriMeshSetTriMergeCallback(Id, null);
                else NativeMethods.dGeomTriMeshSetTriMergeCallback(Id, TriTriMergeCallback);
                triangleMergeCallback = value;
            }
        }

        private int TriCallback(IntPtr triMeshID, IntPtr refObjectID, int triangleIndex)
        {
            var triMesh = (TriMesh)Geom.FromIntPtr(triMeshID);
            var geom = Geom.FromIntPtr(refObjectID);
            return callback(triMesh, geom, triangleIndex) ? 1 : 0;
        }

        private void TriArrayCallback(IntPtr triMeshID, IntPtr refObjectID, IntPtr triIndices, int triCount)
        {
            var triMesh = (TriMesh)Geom.FromIntPtr(triMeshID);
            var geom = Geom.FromIntPtr(refObjectID);
            var triangleIndices = new int[triCount];
            Marshal.Copy(triIndices, triangleIndices, 0, triCount);
            arrayCallback(triMesh, geom, triangleIndices);
        }

        private int TriRayCallback(IntPtr triMeshID, IntPtr rayID, int triangleIndex, dReal u, dReal v)
        {
            var triMesh = (TriMesh)Geom.FromIntPtr(triMeshID);
            var ray = (Ray)Geom.FromIntPtr(rayID);
            return rayCallback(triMesh, ray, triangleIndex, u, v) ? 1 : 0;
        }

        private int TriTriMergeCallback(IntPtr triMeshID, int firstTriangleIndex, int secondTriangleIndex)
        {
            var triMesh = (TriMesh)Geom.FromIntPtr(triMeshID);
            return triangleMergeCallback(triMesh, firstTriangleIndex, secondTriangleIndex);
        }

        public void EnableTemporalCoherence(GeomClass geomClass, bool value)
        {
            NativeMethods.dGeomTriMeshEnableTC(Id, geomClass, value ? 1 : 0);
        }

        public bool IsTemporalCoherenceEnabled(GeomClass geomClass)
        {
            return NativeMethods.dGeomTriMeshIsTCEnabled(Id, geomClass) != 0;
        }

        public void ClearTemporalCoherenceCache()
        {
            NativeMethods.dGeomTriMeshClearTCCache(Id);
        }

        public void GetTriangle(int index, out Vector3 v0, out Vector3 v1, out Vector3 v2)
        {
            NativeMethods.dGeomTriMeshGetTriangle(Id, index, out v0, out v1, out v2);
        }

        public void GetPoint(int index, dReal u, dReal v, out Vector3 result)
        {
            NativeMethods.dGeomTriMeshGetPoint(Id, index, u, v, out result);
        }

        public Vector3 GetPoint(int index, dReal u, dReal v)
        {
            Vector3 result;
            GetPoint(index, u, v, out result);
            return result;
        }
    }

    public delegate bool TriangleCallback(TriMesh triMesh, Geom geom, int triangleIndex);

    public delegate void TriangleArrayCallback(TriMesh triMesh, Geom geom, int[] triangleIndices);

    public delegate bool TriangleRayCallback(TriMesh triMesh, Ray ray, int triangleIndex, dReal u, dReal v);

    public delegate int TriangleTriangleMergeCallback(TriMesh triMesh, int firstTriangleIndex, int secondTriangleIndex);
}
