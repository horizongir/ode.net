using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class LinearMotor : Joint
    {
        public LinearMotor(World world)
            : this(world, null)
        {
        }

        public LinearMotor(World world, JointGroup group)
            : base(NativeMethods.dJointCreateLMotor(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
