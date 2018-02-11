using Microsoft.Win32.SafeHandles;
using Ode.Net.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dGeomID : SafeHandleZeroOrMinusOneIsInvalid
    {
        Space owner;

        internal dGeomID()
            : base(true)
        {
        }

        internal dGeomID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal Space Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        protected override bool ReleaseHandle()
        {
            if (owner == null || !owner.Id.IsClosed)
            {
                NativeMethods.dGeomDestroy(handle);
            }
            return true;
        }
    }
}
