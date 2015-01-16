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
    /// Represents an axis-aligned bounding box.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        /// <summary>
        /// Specifies the minimum X coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MinX;

        /// <summary>
        /// Specifies the maximum X coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MaxX;

        /// <summary>
        /// Specifies the minimum Y coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MinY;

        /// <summary>
        /// Specifies the maximum Y coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MaxY;

        /// <summary>
        /// Specifies the minimum Z coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MinZ;

        /// <summary>
        /// Specifies the maximum Z coordinate of the axis-aligned bounding box.
        /// </summary>
        public dReal MaxZ;
    }
}
