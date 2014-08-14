using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class DoubleBall : Joint
    {
        public DoubleBall(World world)
            : this(world, null)
        {
        }

        public DoubleBall(World world, JointGroup group)
            : base(NativeMethods.dJointCreateDBall(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
