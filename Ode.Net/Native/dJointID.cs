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
        World owner;

        internal dJointID()
            : base(true)
        {
        }

        private dJointID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal World Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        protected override bool ReleaseHandle()
        {
            if (owner == null || !owner.Id.IsClosed)
            {
                NativeMethods.dJointDestroy(handle);
            }
            owner = null;
            return true;
        }
    }
}
