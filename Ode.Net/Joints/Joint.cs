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
        JointFeedback feedback;

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

        public int NumBodies
        {
            get { return NativeMethods.dJointGetNumBodies(id); }
        }

        public bool Enabled
        {
            get { return NativeMethods.dJointIsEnabled(id) != 0; }
            set
            {
                if (value) NativeMethods.dJointEnable(id);
                else NativeMethods.dJointDisable(id);
            }
        }

        public object Data { get; set; }

        public JointType Type
        {
            get { return NativeMethods.dJointGetType(id); }
        }

        public JointFeedback Feedback
        {
            get { return feedback; }
            set
            {
                var handle = value != null ? value.Handle : dJointFeedbackHandle.Null;
                NativeMethods.dJointSetFeedback(id, handle);
                feedback = value;
            }
        }

        public void Attach(Body body1, Body body2)
        {
            var b1 = body1 != null ? body1.Id : dBodyID.Null;
            var b2 = body2 != null ? body2.Id : dBodyID.Null;
            NativeMethods.dJointAttach(id, b1, b2);
        }

        public Body GetBody(int index)
        {
            var body = NativeMethods.dJointGetBody(id, index);
            return Body.FromIntPtr(body);
        }

        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                var handlePtr = NativeMethods.dJointGetData(id);
                var handle = GCHandle.FromIntPtr(handlePtr);
                handle.Free();
                id.Close();
            }
        }
    }
}
