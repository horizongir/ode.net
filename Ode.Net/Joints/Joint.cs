using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    /// <summary>
    /// Represents a joint, or constraint, enforced between two bodies.
    /// </summary>
    public abstract class Joint : IDisposable
    {
        readonly dJointID id;

        internal Joint(dJointID joint)
        {
            id = joint;
        }

        internal static Joint FromIntPtr(IntPtr value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
