using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class DoubleHinge : Joint
    {
        public DoubleHinge(World world)
            : this(world, null)
        {
        }

        public DoubleHinge(World world, JointGroup group)
            : base(NativeMethods.dJointCreateDHinge(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
