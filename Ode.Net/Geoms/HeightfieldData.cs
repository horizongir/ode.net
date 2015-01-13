using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class HeightfieldData : IDisposable
    {
        readonly dHeightfieldDataID id;

        public HeightfieldData()
        {
            id = NativeMethods.dGeomHeightfieldDataCreate();
        }

        internal dHeightfieldDataID Id
        {
            get { return id; }
        }

        public void BuildCallback(
            HeightfieldGetHeight callback,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            NativeMethods.dGeomHeightfieldDataBuildCallback(
                id, IntPtr.Zero, (data, x, z) => callback(x, z),
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildByte(
            byte[] heightData,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            if (heightData == null)
            {
                throw new ArgumentNullException("heightData");
            }

            NativeMethods.dGeomHeightfieldDataBuildByte(
                id, heightData, 1,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildByte(
            IntPtr heightData, bool copy,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            NativeMethods.dGeomHeightfieldDataBuildByte(
                id, heightData, copy ? 1 : 0,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildShort(
            short[] heightData,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            if (heightData == null)
            {
                throw new ArgumentNullException("heightData");
            }

            NativeMethods.dGeomHeightfieldDataBuildShort(
                id, heightData, 1,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildShort(
            IntPtr heightData, bool copy,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            NativeMethods.dGeomHeightfieldDataBuildShort(
                id, heightData, copy ? 1 : 0,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildSingle(
            float[] heightData,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            if (heightData == null)
            {
                throw new ArgumentNullException("heightData");
            }

            NativeMethods.dGeomHeightfieldDataBuildSingle(
                id, heightData, 1,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildSingle(
            IntPtr heightData, bool copy,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            NativeMethods.dGeomHeightfieldDataBuildSingle(
                id, heightData, copy ? 1 : 0,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildDouble(
            double[] heightData,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            if (heightData == null)
            {
                throw new ArgumentNullException("heightData");
            }

            NativeMethods.dGeomHeightfieldDataBuildDouble(
                id, heightData, 1,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void BuildDouble(
            IntPtr heightData, bool copy,
            dReal width, dReal depth, int widthSamples, int depthSamples,
            dReal scale, dReal offset, dReal thickness, bool wrap)
        {
            NativeMethods.dGeomHeightfieldDataBuildDouble(
                id, heightData, copy ? 1 : 0,
                width, depth, widthSamples, depthSamples,
                scale, offset, thickness, wrap ? 1 : 0);
        }

        public void SetBounds(dReal minHeight, dReal maxHeight)
        {
            NativeMethods.dGeomHeightfieldDataSetBounds(id, minHeight, maxHeight);
        }

        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                id.Close();
            }
        }
    }

    public delegate dReal HeightfieldGetHeight(int x, int z);
}
