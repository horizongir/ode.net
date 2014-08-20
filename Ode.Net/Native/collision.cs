using Ode.Net.Geoms;
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
        internal const int MaxUserClasses = 4;

        #region Collision Detection

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomDestroy(IntPtr geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetData(dGeomID geom, IntPtr data);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetData(IntPtr geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetData(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetBody(dGeomID geom, dBodyID body);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetBody(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetPosition(dGeomID geom, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetRotation(dGeomID geom, ref Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetQuaternion(dGeomID geom, ref Quaternion Q);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetPosition(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCopyPosition(dGeomID geom, out Vector3 pos);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetRotation(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCopyRotation(dGeomID geom, out Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomGetQuaternion(dGeomID geom, out Quaternion result);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomGetAABB(dGeomID geom, out BoundingBox aabb);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomIsSpace(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetSpace(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GeomClass dGeomGetClass(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetCategoryBits(dGeomID geom, uint bits);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetCollideBits(dGeomID geom, uint bits);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint dGeomGetCategoryBits(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint dGeomGetCollideBits(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomEnable(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomDisable(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomIsEnabled(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomLowLevelControl(
            dGeomID geom,
            int controlClass,
            int controlCode,
            IntPtr dataValue,
            out int dataSize);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomGetRelPointPos
        (
          dGeomID geom, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomGetPosRelPoint
        (
          dGeomID geom, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomVectorToWorld
        (
          dGeomID geom, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomVectorFromWorld
        (
          dGeomID geom, dReal px, dReal py, dReal pz,
          out Vector3 result
        );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetPosition(dGeomID geom, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetRotation(dGeomID geom, ref Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetQuaternion(dGeomID geom, ref Quaternion Q);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetWorldPosition(dGeomID geom, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetWorldRotation(dGeomID geom, ref Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetOffsetWorldQuaternion(dGeomID geom, ref Quaternion Q);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomClearOffset(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomIsOffset(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetOffsetPosition(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCopyOffsetPosition(dGeomID geom, out Vector3 pos);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dGeomGetOffsetRotation(dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCopyOffsetRotation(dGeomID geom, out Matrix3 R);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomGetOffsetQuaternion(dGeomID geom, out Quaternion result);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dCollide(
            dGeomID o1,
            dGeomID o2,
            ContactGenerationFlags flags,
            [Out]ContactGeom[] contact,
            int skip);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceCollide(dSpaceID space, IntPtr data, dNearCallback callback);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceCollide2(dGeomID space1, dGeomID space2, IntPtr data, dNearCallback callback);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateSphere(dSpaceID space, dReal radius);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSphereSetRadius(dGeomID sphere, dReal radius);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomSphereGetRadius(dGeomID sphere);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomSpherePointDepth(dGeomID sphere, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateConvex(
            dSpaceID space,
            dReal[] _planes,
            uint _planecount,
            dReal[] _points,
            uint _pointcount,
            uint[] _polygons);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomSetConvex(
            dGeomID g,
            dReal[] _planes,
            uint _count,
            dReal[] _points,
            uint _pointcount,
            uint[] _polygons);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateBox(dSpaceID space, dReal lx, dReal ly, dReal lz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomBoxSetLengths(dGeomID box, dReal lx, dReal ly, dReal lz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomBoxGetLengths(dGeomID box, out Vector3 result);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomBoxPointDepth(dGeomID box, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreatePlane(dSpaceID space, dReal a, dReal b, dReal c, dReal d);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomPlaneSetParams(dGeomID plane, dReal a, dReal b, dReal c, dReal d);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomPlaneGetParams(dGeomID plane, out Vector4 result);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomPlanePointDepth(dGeomID plane, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateCapsule(dSpaceID space, dReal radius, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCapsuleSetParams(dGeomID ccylinder, dReal radius, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCapsuleGetParams(dGeomID ccylinder, out dReal radius, out dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomCapsulePointDepth(dGeomID ccylinder, dReal x, dReal y, dReal z);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateCylinder(dSpaceID space, dReal radius, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCylinderSetParams(dGeomID cylinder, dReal radius, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomCylinderGetParams(dGeomID cylinder, out dReal radius, out dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateRay(dSpaceID space, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRaySetLength(dGeomID ray, dReal length);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dReal dGeomRayGetLength(dGeomID ray);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRaySet(
            dGeomID ray, dReal px, dReal py, dReal pz,
            dReal dx, dReal dy, dReal dz);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRayGet(dGeomID ray, out Vector3 start, out Vector3 dir);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRaySetParams(dGeomID g, int FirstContact, int BackfaceCull);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRayGetParams(dGeomID g, out int FirstContact, out int BackfaceCull);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomRaySetClosestHit(dGeomID g, int closestHit);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomRayGetClosestHit(dGeomID g);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateGeomTransform(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomTransformSetGeom(dGeomID g, dGeomID obj);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dGeomTransformGetGeom(dGeomID g);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomTransformSetCleanup(dGeomID g, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomTransformGetCleanup(dGeomID g);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomTransformSetInfo(dGeomID g, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dGeomTransformGetInfo(dGeomID g);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dGeomID dCreateHeightfield(
            dSpaceID space,
            dHeightfieldDataID data,
            int bPlaceable);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dHeightfieldDataID dGeomHeightfieldDataCreate();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataDestroy(IntPtr d);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataBuildCallback(dHeightfieldDataID d,
                        IntPtr pUserData, dHeightfieldGetHeight pCallback,
                        dReal width, dReal depth, int widthSamples, int depthSamples,
                        dReal scale, dReal offset, dReal thickness, int bWrap);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataBuildByte(dHeightfieldDataID d,
                        byte[] pHeightData, int bCopyHeightData,
                        dReal width, dReal depth, int widthSamples, int depthSamples,
                        dReal scale, dReal offset, dReal thickness, int bWrap);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataBuildShort(dHeightfieldDataID d,
                        short[] pHeightData, int bCopyHeightData,
                        dReal width, dReal depth, int widthSamples, int depthSamples,
                        dReal scale, dReal offset, dReal thickness, int bWrap);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataBuildSingle(dHeightfieldDataID d,
                        float[] pHeightData, int bCopyHeightData,
                        dReal width, dReal depth, int widthSamples, int depthSamples,
                        dReal scale, dReal offset, dReal thickness, int bWrap);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataBuildDouble(dHeightfieldDataID d,
                        double[] pHeightData, int bCopyHeightData,
                        dReal width, dReal depth, int widthSamples, int depthSamples,
                        dReal scale, dReal offset, dReal thickness, int bWrap);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldDataSetBounds(dHeightfieldDataID d,
                        dReal minHeight, dReal maxHeight);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dGeomHeightfieldSetHeightfieldData(dGeomID g, dHeightfieldDataID d);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dHeightfieldDataID dGeomHeightfieldGetHeightfieldData(dGeomID g);

        #endregion

        #region Space

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dSpaceID dSimpleSpaceCreate(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dSpaceID dHashSpaceCreate(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dSpaceID dQuadTreeSpaceCreate(dSpaceID space, ref Vector3 Center, ref Vector3 Extents, int Depth);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern dSpaceID dSweepAndPruneSpaceCreate(dSpaceID space, int axisorder);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceDestroy(IntPtr space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dHashSpaceSetLevels(dSpaceID space, int minlevel, int maxlevel);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dHashSpaceGetLevels(dSpaceID space, out int minlevel, out int maxlevel);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceSetCleanup(dSpaceID space, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceGetCleanup(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceSetSublevel(dSpaceID space, int sublevel);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceGetSublevel(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceSetManualCleanup(dSpaceID space, int mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceGetManualCleanup(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceAdd(dSpaceID space, dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceRemove(dSpaceID space, dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceQuery(dSpaceID space, dGeomID geom);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void dSpaceClean(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceGetNumGeoms(dSpaceID space);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr dSpaceGetGeom(dSpaceID space, int i);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int dSpaceGetClass(dSpaceID space);

        #endregion
    }
}
