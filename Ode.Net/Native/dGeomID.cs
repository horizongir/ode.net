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
        internal static readonly dGeomID Null = new NulldGeomID();

        internal dGeomID()
            : base(true)
        {
        }

        private dGeomID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dWorldDestroy(handle);
            return true;
        }

        class NulldGeomID : dGeomID
        {
            public NulldGeomID()
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
