using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Hinge2 : Joint
    {
        public Hinge2(World world)
            : this(world, null)
        {
        }

        public Hinge2(World world, JointGroup group)
            : base(NativeMethods.dJointCreateHinge2(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
