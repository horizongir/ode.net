using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dJointID : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dJointID Null = new NulldJointID();

        internal dJointID()
            : base(true)
        {
        }

        private dJointID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dWorldDestroy(handle);
            return true;
        }

        class NulldJointID : dJointID
        {
            public NulldJointID()
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
