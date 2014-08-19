using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dHeightfieldDataID : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dHeightfieldDataID Null = new NulldHeightfieldDataID();

        internal dHeightfieldDataID()
            : base(true)
        {
        }

        private dHeightfieldDataID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dGeomHeightfieldDataDestroy(handle);
            return true;
        }

        class NulldHeightfieldDataID : dHeightfieldDataID
        {
            public NulldHeightfieldDataID()
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
