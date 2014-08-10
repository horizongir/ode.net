using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dBodyID : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dBodyID Null = new NulldBodyID();

        internal dBodyID()
            : base(true)
        {
        }

        private dBodyID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dBodyDestroy(handle);
            return true;
        }

        class NulldBodyID : dBodyID
        {
            public NulldBodyID()
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
