using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Slider : Joint
    {
        public Slider(World world)
            : this(world, null)
        {
        }

        public Slider(World world, JointGroup group)
            : base(NativeMethods.dJointCreateSlider(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
