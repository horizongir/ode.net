using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dJointFeedback : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dJointFeedback Null = new NulldJointFeedback();

        internal dJointFeedback()
            : base(true)
        {
        }

        private dJointFeedback(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dWorldDestroy(handle);
            return true;
        }

        class NulldJointFeedback : dJointFeedback
        {
            public NulldJointFeedback()
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
