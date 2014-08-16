using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Plane2D : Joint
    {
        public Plane2D(World world)
            : this(world, null)
        {
        }

        public Plane2D(World world, JointGroup group)
            : base(NativeMethods.dJointCreatePlane2D(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }
    }
}
