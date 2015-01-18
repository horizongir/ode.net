using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dSpaceID : dGeomID
    {
        internal static readonly dSpaceID Null = new NulldSpaceID();

        internal dSpaceID()
            : base(true)
        {
        }

        private dSpaceID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dSpaceDestroy(handle);
            return true;
        }

        class NulldSpaceID : dSpaceID
        {
            public NulldSpaceID()
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
