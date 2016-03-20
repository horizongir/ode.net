using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    class DataHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public DataHandle(int cb)
            : base(true)
        {
            SetHandle(Marshal.AllocHGlobal(cb));
        }

        public void Copy(float[] data)
        {
            Marshal.Copy(data, 0, handle, data.Length);
        }

        public void Copy(double[] data)
        {
            Marshal.Copy(data, 0, handle, data.Length);
        }

        public void Copy(int[] data)
        {
            Marshal.Copy(data, 0, handle, data.Length);
        }

        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }
    }
}
