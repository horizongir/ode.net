using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;
using dThreadingImplementationID = System.IntPtr;

namespace Ode.Net.Native
{
    static partial class NativeMethods
    {
        #region World

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dWorldID dWorldCreate();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldDestroy(IntPtr world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetGravity(dWorldID w, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldGetGravity(dWorldID w, out Vector3 gravity);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetERP(dWorldID w, dReal erp);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetERP(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetCFM(dWorldID w, dReal cfm);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetCFM(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetStepIslandsProcessingMaxThreadCount(dWorldID w, uint count);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint dWorldGetStepIslandsProcessingMaxThreadCount(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldUseSharedWorkingMemory(dWorldID w, dWorldID from_world);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldCleanupWorkingMemory(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryReservationPolicy(dWorldID w, IntPtr policyinfo);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryReservationPolicy(dWorldID w, ref dWorldStepReserveInfo policyinfo);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryManager(dWorldID w, IntPtr memfuncs);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldSetStepMemoryManager(dWorldID w, ref dWorldStepMemoryFunctionsInfo memfuncs);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetStepThreadingImplementation(dWorldID w, ref dThreadingFunctionsInfo functions_info, dThreadingImplementationID threading_impl);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldStep(dWorldID w, dReal stepsize);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldQuickStep(dWorldID w, dReal stepsize);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldImpulseToForce(
            dWorldID w, dReal stepsize,
            dReal ix, dReal iy, dReal iz, out Vector3 force);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetQuickStepNumIterations(dWorldID w, int num);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldGetQuickStepNumIterations(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetQuickStepW(dWorldID w, dReal over_relaxation);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetQuickStepW(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetContactMaxCorrectingVel(dWorldID w, dReal vel);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetContactMaxCorrectingVel(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetContactSurfaceLayer(dWorldID w, dReal depth);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetContactSurfaceLayer(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetAutoDisableLinearThreshold(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableLinearThreshold(dWorldID w, dReal linear_threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetAutoDisableAngularThreshold(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableAngularThreshold(dWorldID w, dReal angular_threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldGetAutoDisableAverageSamplesCount(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableAverageSamplesCount(dWorldID w, uint average_samples_count);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldGetAutoDisableSteps(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableSteps(dWorldID w, int steps);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetAutoDisableTime(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableTime(dWorldID w, dReal time);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dWorldGetAutoDisableFlag(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAutoDisableFlag(dWorldID w, int do_auto_disable);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetLinearDampingThreshold(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetLinearDampingThreshold(dWorldID w, dReal threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetAngularDampingThreshold(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAngularDampingThreshold(dWorldID w, dReal threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetLinearDamping(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetLinearDamping(dWorldID w, dReal scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetAngularDamping(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetAngularDamping(dWorldID w, dReal scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetDamping(
            dWorldID w,
            dReal linear_scale,
            dReal angular_scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dWorldGetMaxAngularSpeed(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dWorldSetMaxAngularSpeed(dWorldID w, dReal max_speed);

        #endregion
    }
}
