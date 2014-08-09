using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
#if SINGLE_PRECISION
    using dReal = System.Single;
#elif DOUBLE_PRECISION
    using dReal = System.Double;
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif

    static partial class NativeMethods
    {
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dWorldID dWorldCreate();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldDestroy(IntPtr world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetGravity(dWorldID world, dReal x, dReal y, dReal z);
    }
}
