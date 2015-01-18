using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dGeomID : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal dGeomID()
            : base(true)
        {
        }

        internal dGeomID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dGeomDestroy(handle);
            return true;
        }
    }
}
