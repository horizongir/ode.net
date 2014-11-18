using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public class SweepAndPruneSpace : Space
    {
        public SweepAndPruneSpace(AxisOrder axisOrder)
            : this(null, axisOrder)
        {
        }

        public SweepAndPruneSpace(Space space, AxisOrder axisOrder)
            : base(NativeMethods.dSweepAndPruneSpaceCreate(space != null ? space.Id : dSpaceID.Null, axisOrder))
        {
        }
    }
}
