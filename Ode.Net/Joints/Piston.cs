using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Piston : Joint
    {
        public Piston(World world)
            : this(world, null)
        {
        }

        public Piston(World world, JointGroup group)
            : base(NativeMethods.dJointCreatePiston(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
