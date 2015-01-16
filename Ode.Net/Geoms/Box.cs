using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Represents a box geom.
    /// </summary>
    public sealed class Box : Geom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class with the
        /// specified dimensions.
        /// </summary>
        /// <param name="lengthX">The length of the box along the X axis.</param>
        /// <param name="lengthY">The length of the box along the Y axis.</param>
        /// <param name="lengthZ">The length of the box along the Z axis.</param>
        public Box(dReal lengthX, dReal lengthY, dReal lengthZ)
            : this(null, lengthX, lengthY, lengthZ)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class on the
        /// given space and with the specified dimensions.
        /// </summary>
        /// <param name="space">The space that is to contain the geom.</param>
        /// <param name="lengthX">The length of the box along the X axis.</param>
        /// <param name="lengthY">The length of the box along the Y axis.</param>
        /// <param name="lengthZ">The length of the box along the Z axis.</param>
        public Box(Space space, dReal lengthX, dReal lengthY, dReal lengthZ)
            : base(NativeMethods.dCreateBox(space != null ? space.Id : dSpaceID.Null, lengthX, lengthY, lengthZ))
        {
        }

        /// <summary>
        /// Gets or sets the box dimensions along the X, Y and Z axes.
        /// </summary>
        public Vector3 Lengths
        {
            get
            {
                Vector3 lengths;
                NativeMethods.dGeomBoxGetLengths(Id, out lengths);
                return lengths;
            }
            set
            {
                NativeMethods.dGeomBoxSetLengths(Id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Calculates the depth of the specified point within the box.
        /// </summary>
        /// <param name="x">The x-coordinate of the point to test.</param>
        /// <param name="y">The y-coordinate of the point to test.</param>
        /// <param name="z">The z-coordinate of the point to test.</param>
        /// <returns>
        /// The depth of the point. Points inside the box will have a
        /// positive depth, points outside it will have a negative depth,
        /// and points on the surface will have a depth of zero.
        /// </returns>
        public dReal PointDepth(dReal x, dReal y, dReal z)
        {
            return NativeMethods.dGeomBoxPointDepth(Id, x, y, z);
        }
    }
}
