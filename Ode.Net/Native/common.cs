using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
    static partial class NativeMethods
    {
#if SINGLE_PRECISION
        const string libName = "ode_single";
#elif DOUBLE_PRECISION
        const string libName = "ode_double";
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGetConfiguration();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int dCheckConfiguration(string token);
    }
}
