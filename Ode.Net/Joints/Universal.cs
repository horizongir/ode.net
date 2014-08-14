using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Universal : Joint
    {
        public Universal(World world)
            : this(world, null)
        {
        }

        public Universal(World world, JointGroup group)
            : base(NativeMethods.dJointCreateUniversal(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
