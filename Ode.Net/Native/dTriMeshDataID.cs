using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class dTriMeshDataID : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly dTriMeshDataID Null = new NulldTriMeshDataID();

        internal dTriMeshDataID()
            : base(true)
        {
        }

        private dTriMeshDataID(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.dGeomTriMeshDataDestroy(handle);
            return true;
        }

        class NulldTriMeshDataID : dTriMeshDataID
        {
            public NulldTriMeshDataID()
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
