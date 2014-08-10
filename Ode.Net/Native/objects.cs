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

        #region Rigid Bodies

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetAutoDisableLinearThreshold(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableLinearThreshold(dBodyID b, dReal linear_average_threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetAutoDisableAngularThreshold(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableAngularThreshold(dBodyID b, dReal angular_average_threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetAutoDisableAverageSamplesCount(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableAverageSamplesCount(dBodyID b, uint average_samples_count);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetAutoDisableSteps(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableSteps(dBodyID b, int steps);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetAutoDisableTime(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableTime(dBodyID b, dReal time);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetAutoDisableFlag(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableFlag(dBodyID b, int do_auto_disable);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAutoDisableDefaults(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dWorldID dBodyGetWorld(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dBodyID dBodyCreate(dWorldID w);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyDestroy(IntPtr b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetData(dBodyID b, IntPtr data);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetData(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetPosition(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetRotation(dBodyID b, ref Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetQuaternion(dBodyID b, ref Quaternion q);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetLinearVel(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAngularVel(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetPosition(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyCopyPosition(dBodyID body, out Vector3 pos);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetRotation(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyCopyRotation(dBodyID b, out Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetQuaternion(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyCopyQuaternion(dBodyID body, out Quaternion quat);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetLinearVel(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetAngularVel(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetMass(dBodyID b, ref Mass mass);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetMass(dBodyID b, out Mass mass);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddForce(dBodyID b, dReal fx, dReal fy, dReal fz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddTorque(dBodyID b, dReal fx, dReal fy, dReal fz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddRelForce(dBodyID b, dReal fx, dReal fy, dReal fz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddRelTorque(dBodyID b, dReal fx, dReal fy, dReal fz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddForceAtPos(dBodyID b, dReal fx, dReal fy, dReal fz,
                                    dReal px, dReal py, dReal pz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddForceAtRelPos(dBodyID b, dReal fx, dReal fy, dReal fz,
                                    dReal px, dReal py, dReal pz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddRelForceAtPos(dBodyID b, dReal fx, dReal fy, dReal fz,
                                    dReal px, dReal py, dReal pz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyAddRelForceAtRelPos(dBodyID b, dReal fx, dReal fy, dReal fz,
                                    dReal px, dReal py, dReal pz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetForce(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dBodyGetTorque(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetForce(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetTorque(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetRelPointPos
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetRelPointVel
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetPointVel
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetPosRelPoint
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyVectorToWorld
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyVectorFromWorld
        (
          dBodyID b, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetFiniteRotationMode(dBodyID b, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetFiniteRotationAxis(dBodyID b, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetFiniteRotationMode(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyGetFiniteRotationAxis(dBodyID b, out Vector3 result);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetNumJoints(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dJointID dBodyGetJoint(dBodyID b, int index);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetDynamic(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetKinematic(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyIsKinematic(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyEnable(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodyDisable(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyIsEnabled(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetGravityMode(dBodyID b, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetGravityMode(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetMovedCallback(dBodyID b, MovedCallback callback);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dBodyGetFirstGeom(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dBodyGetNextGeom(dGeomID g);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetDampingDefaults(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetLinearDamping(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetLinearDamping(dBodyID b, dReal scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetAngularDamping(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAngularDamping(dBodyID b, dReal scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetDamping(dBodyID b, dReal linear_scale, dReal angular_scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetLinearDampingThreshold(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetLinearDampingThreshold(dBodyID b, dReal threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetAngularDampingThreshold(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetAngularDampingThreshold(dBodyID b, dReal threshold);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dBodyGetMaxAngularSpeed(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetMaxAngularSpeed(dBodyID b, dReal max_speed);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dBodyGetGyroscopicMode(dBodyID b);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dBodySetGyroscopicMode(dBodyID b, int enabled);

        #endregion
    }
}
