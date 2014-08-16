using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Fixed : Joint
    {
        public Fixed(World world)
            : this(world, null)
        {
        }

        public Fixed(World world, JointGroup group)
            : base(NativeMethods.dJointCreateFixed(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
