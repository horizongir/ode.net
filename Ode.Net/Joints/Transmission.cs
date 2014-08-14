using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Transmission : Joint
    {
        public Transmission(World world)
            : this(world, null)
        {
        }

        public Transmission(World world, JointGroup group)
            : base(NativeMethods.dJointCreateTransmission(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
