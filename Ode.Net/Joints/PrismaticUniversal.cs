using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class PrismaticUniversal : Joint
    {
        public PrismaticUniversal(World world)
            : this(world, null)
        {
        }

        public PrismaticUniversal(World world, JointGroup group)
            : base(NativeMethods.dJointCreatePU(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
