using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public sealed class SimpleSpace : Space
    {
        public SimpleSpace()
            : this(null)
        {
        }

        public SimpleSpace(Space space)
            : base(NativeMethods.dSimpleSpaceCreate(space != null ? space.Id : dSpaceID.Null))
        {
        }
    }
}
