using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class PrismaticRotoide : Joint
    {
        public PrismaticRotoide(World world)
            : this(world, null)
        {
        }

        public PrismaticRotoide(World world, JointGroup group)
            : base(NativeMethods.dJointCreatePR(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
