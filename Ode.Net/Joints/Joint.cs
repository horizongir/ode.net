using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            var handle = GCHandle.Alloc(this);
            NativeMethods.dJointSetData(id, GCHandle.ToIntPtr(handle));
        }

        internal static Joint FromIntPtr(IntPtr value)
        {
            if (value == IntPtr.Zero) return null;
            var handlePtr = NativeMethods.dJointGetData(value);
            if (handlePtr == IntPtr.Zero) return null;
            var handle = GCHandle.FromIntPtr(handlePtr);
            return (Joint)handle.Target;
        }

        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                var handlePtr = NativeMethods.dJointGetData(id.DangerousGetHandle());
                var handle = GCHandle.FromIntPtr(handlePtr);
                handle.Free();
                id.Close();
            }
        }
    }
}
