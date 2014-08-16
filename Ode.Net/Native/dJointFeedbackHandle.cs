using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dJointFeedbackHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dJointFeedbackHandle Null = new NulldJointFeedbackHandle();

        internal dJointFeedbackHandle()
            : base(true)
        {
            var handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(dJointFeedback)));
            SetHandle(handle);
        }

        private dJointFeedbackHandle(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal Vector3 ForceOnBody1
        {
            get
            {
                unsafe
                {
                    return ((dJointFeedback*)handle)->f1;
                }
            }
        }

        internal Vector3 TorqueOnBody1
        {
            get
            {
                unsafe
                {
                    return ((dJointFeedback*)handle)->t1;
                }
            }
        }

        internal Vector3 ForceOnBody2
        {
            get
            {
                unsafe
                {
                    return ((dJointFeedback*)handle)->f2;
                }
            }
        }

        internal Vector3 TorqueOnBody2
        {
            get
            {
                unsafe
                {
                    return ((dJointFeedback*)handle)->t2;
                }
            }
        }

        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }

        class NulldJointFeedbackHandle : dJointFeedbackHandle
        {
            public NulldJointFeedbackHandle()
                : base(false)
            {
            }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
