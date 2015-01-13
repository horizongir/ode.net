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
    public sealed class Convex : Geom
    {
        ConvexData data;

        public Convex(dReal[] planes, dReal[] points, int[] polygons)
            : this(null, planes, points, polygons)
        {
        }

        public Convex(Space space, dReal[] planes, dReal[] points, int[] polygons)
            : this(space, new ConvexData(planes, points, polygons))
        {
        }

        private Convex(Space space, ConvexData data)
            : base(NativeMethods.dCreateConvex(space != null ? space.Id : dSpaceID.Null,
                                               data._planes, data._planeCount,
                                               data._points, data._pointCount,
                                               data._polygons))
        {
        }

        public void SetConvex(dReal[] planes, dReal[] points, int[] polygons)
        {
        }

        class ConvexData : IDisposable
        {
            internal IntPtr _planes;
            internal uint _planeCount;
            internal IntPtr _points;
            internal uint _pointCount;
            internal IntPtr _polygons;

            internal ConvexData(dReal[] planes, dReal[] points, int[] polygons)
            {
                _planeCount = (uint)planes.Length;
                _pointCount = (uint)points.Length;
                _planes = Marshal.AllocHGlobal(planes.Length * Marshal.SizeOf(typeof(dReal)));
                _points = Marshal.AllocHGlobal(points.Length * Marshal.SizeOf(typeof(dReal)));
                _polygons = Marshal.AllocHGlobal(polygons.Length * Marshal.SizeOf(typeof(uint)));
                Marshal.Copy(planes, 0, _planes, planes.Length);
                Marshal.Copy(points, 0, _points, points.Length);
                Marshal.Copy(polygons, 0, _polygons, polygons.Length);
            }

            private static void ReleaseDataStore(ref IntPtr storeHandle)
            {
                if (storeHandle != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(storeHandle);
                }

                storeHandle = IntPtr.Zero;
            }

            public void Dispose()
            {
                ReleaseDataStore(ref _planes);
                ReleaseDataStore(ref _points);
                ReleaseDataStore(ref _polygons);
            }
        }
    }
}
