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

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetERP(dWorldID world, dReal erp);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetERP(dWorldID world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetCFM(dWorldID world, dReal cfm);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetCFM(dWorldID world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetStepIslandsProcessingMaxThreadCount(dWorldID world, uint count);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint dWorldGetStepIslandsProcessingMaxThreadCount(dWorldID world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldUseSharedWorkingMemory(dWorldID world, dWorldID from_world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldCleanupWorkingMemory(dWorldID world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryReservationPolicy(dWorldID world, IntPtr policyinfo);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryReservationPolicy(dWorldID world, ref dWorldStepReserveInfo policyinfo);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryManager(dWorldID world, IntPtr memfuncs);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryManager(dWorldID world, ref dWorldStepMemoryFunctionsInfo memfuncs);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldStep(dWorldID world, dReal stepsize);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldQuickStep(dWorldID world, dReal stepsize);
    }
}
