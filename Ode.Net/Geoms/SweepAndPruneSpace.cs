﻿using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents a sweep-and-prune collision space.
    /// </summary>
    public sealed class SweepAndPruneSpace : Space
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SweepAndPruneSpace"/> class.
        /// </summary>
        /// <param name="axisOrder">The spatial axes ordering for the sweep-and-prune space.</param>
        public SweepAndPruneSpace(AxisOrder axisOrder)
            : this(null, axisOrder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepAndPruneSpace"/> class
        /// inside the specified space.
        /// </summary>
        /// <param name="space">The space which will contain the new sweep-and-prune space.</param>
        /// <param name="axisOrder">The spatial axes ordering for the sweep-and-prune space.</param>
        public SweepAndPruneSpace(Space space, AxisOrder axisOrder)
            : base(NativeMethods.dSweepAndPruneSpaceCreate(space != null ? space.Id : dSpaceID.Null, axisOrder))
        {
        }
    }
}
