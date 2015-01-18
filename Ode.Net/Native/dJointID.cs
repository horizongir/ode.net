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
            NativeMethods.dJointDestroy(handle);
            return true;
        }
    }
}
