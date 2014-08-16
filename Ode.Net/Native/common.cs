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
        const string libName = "ode_single";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGetConfiguration();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int dCheckConfiguration(string token);
    }
}
