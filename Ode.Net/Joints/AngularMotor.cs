using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class AngularMotor : Joint
    {
        public AngularMotor(World world)
            : this(world, null)
        {
        }

        public AngularMotor(World world, JointGroup group)
            : base(NativeMethods.dJointCreateAMotor(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
