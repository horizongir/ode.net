using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net
{
    /// <summary>
    /// Represents a memory reservation policy descriptor for world stepping functions.
    /// </summary>
    public class WorldStepReserveInfo
    {
        internal dWorldStepReserveInfo info;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldStepReserveInfo"/> class with
        /// the specified memory reservation policy parameters.
        /// </summary>
        /// <param name="reserveFactor">
        /// A quotient that is multiplied by required memory size to allocate extra
        /// reserve whenever reallocation is needed.
        /// </param>
        /// <param name="reserveMinimum">
        /// A minimum size that is checked against whenever reallocation is needed
        /// to allocate expected working memory minimum at once without extra
        /// reallocations as number of bodies/joints grows.
        /// </param>
        public WorldStepReserveInfo(float reserveFactor = 1.2f, int reserveMinimum = 65536)
        {
            info.struct_size = (uint)Marshal.SizeOf(typeof(dWorldStepReserveInfo));
            info.reserve_factor = reserveFactor;
            info.reserve_minimum = (uint)reserveMinimum;
        }

        /// <summary>
        /// Gets or sets a quotient that is multiplied by required memory size
        /// to allocate extra reserve whenever reallocation is needed.
        /// </summary>
        public float ReserveFactor
        {
            get { return info.reserve_factor; }
            set { info.reserve_factor = value; }
        }

        /// <summary>
        /// Gets or sets a minimum size that is checked against whenever reallocation
        /// is needed to allocate expected working memory minimum at once without extra
        /// reallocations as number of bodies/joints grows.
        /// </summary>
        public int ReserveMinimum
        {
            get { return (int)info.reserve_minimum; }
            set { info.reserve_minimum = (uint)value; }
        }
    }
}
