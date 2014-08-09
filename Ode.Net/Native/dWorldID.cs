using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dWorldID : SafeHandleZeroOrMinusOneIsInvalid
    {
        public dWorldID()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dWorldDestroy(handle);
            return true;
        }
    }
}
