using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct dWorldStepReserveInfo
    {
        internal uint struct_size;
        internal float reserve_factor;
        internal uint reserve_minimum;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct dWorldStepMemoryFunctionsInfo
    {
        internal uint struct_size;
        internal IntPtr alloc_block;
        internal IntPtr shrink_block;
        internal IntPtr free_block;
    }
}
