using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Native
{
    static partial class NativeMethods
    {
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dWorldID dWorldCreate();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldDestroy(IntPtr world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetGravity(dWorldID world, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldGetGravity(dWorldID world, out Vector3 gravity);
    }
}
