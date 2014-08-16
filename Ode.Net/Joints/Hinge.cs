using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Hinge : Joint
    {
        public Hinge(World world)
            : this(world, null)
        {
        }

        public Hinge(World world, JointGroup group)
            : base(NativeMethods.dJointCreateHinge(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
