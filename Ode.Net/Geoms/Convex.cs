using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#if SINGLE_PRECISION
using dReal = System.Single;
#elif DOUBLE_PRECISION
using dReal = System.Double;
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents a convex hull geom.
    /// </summary>
    public sealed class Convex : Geom
    {
        ConvexData data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Convex"/> class with the
        /// specified convex hull data.
        /// </summary>
        /// <param name="planes">
        /// The planes' definition array. Each polygon in the convex hull will be
        /// attached to one of these planes. Each plane is defined by a quadruplet
        /// of the a, b, c and d parameters of the plane equation.
        /// </param>
        /// <param name="points">
        /// The array of points, aligned in triplets of x, y and z components.
        /// </param>
        /// <param name="polygons">
        /// The polygons' definition array. Each element in the array is an index
        /// to a previously defined point in the array of point triplets.
        /// Each polygon definition sequence begins and ends in the same point.
        /// There must be as many polygon definition sequences as the number of planes.
        /// </param>
        public Convex(dReal[] planes, dReal[] points, int[] polygons)
            : this(null, planes, points, polygons)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Convex"/> class on the
        /// given space and with the specified convex hull data.
        /// </summary>
        /// <param name="space">The space that is to contain the geom.</param>
        /// <param name="planes">
        /// The planes' definition array. Each polygon in the convex hull will be
        /// attached to one of these planes. Each plane is defined by a quadruplet
        /// of the a, b, c and d parameters of the plane equation.
        /// </param>
        /// <param name="points">
        /// The array of points, aligned in triplets of x, y and z components.
        /// </param>
        /// <param name="polygons">
        /// The polygons' definition array. Each element in the array is an index
        /// to a previously defined point in the array of point triplets.
        /// Each polygon definition sequence begins and ends in the same point.
        /// There must be as many polygon definition sequences as the number of planes.
        /// </param>
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
            this.data = data;
        }

        /// <summary>
        /// Sets the convex hull data.
        /// </summary>
        /// <param name="planes">
        /// The planes' definition array. Each polygon in the convex hull will be
        /// attached to one of these planes. Each plane is defined by a quadruplet
        /// of the a, b, c and d parameters of the plane equation.
        /// </param>
        /// <param name="points">
        /// The array of points, aligned in triplets of x, y and z components.
        /// </param>
        /// <param name="polygons">
        /// The polygons' definition array. Each element in the array is an index
        /// to a previously defined point in the array of point triplets.
        /// Each polygon definition sequence begins and ends in the same point.
        /// There must be as many polygon definition sequences as the number of planes.
        /// </param>
        public void SetConvex(dReal[] planes, dReal[] points, int[] polygons)
        {
            if (data != null)
            {
                data.Dispose();
            }

            data = new ConvexData(planes, points, polygons);
            NativeMethods.dGeomSetConvex(Id, data._planes, data._planeCount,
                                         data._points, data._pointCount,
                                         data._polygons);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="Convex"/> class
        /// specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">
        /// <b>true</b> for a normal dispose operation; <b>false</b> to finalize
        /// the geom.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (data != null)
            {
                if (disposing)
                {
                    data.Dispose();
                    data = null;
                }
            }

            base.Dispose(disposing);
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

            ~ConvexData()
            {
                Dispose(false);
            }

            private static void ReleaseDataStore(ref IntPtr storeHandle)
            {
                if (storeHandle != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(storeHandle);
                }

                storeHandle = IntPtr.Zero;
            }

            private void Dispose(bool disposing)
            {
                ReleaseDataStore(ref _planes);
                ReleaseDataStore(ref _points);
                ReleaseDataStore(ref _polygons);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
