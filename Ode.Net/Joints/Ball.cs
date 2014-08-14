﻿using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class Ball : Joint
    {
        public Ball(World world)
            : this(world, null)
        {
        }

        public Ball(World world, JointGroup group)
            : base(NativeMethods.dJointCreateBall(world.Id, group != null ? group.Id : dJointGroupID.Null))
        {
        }
    }
}
