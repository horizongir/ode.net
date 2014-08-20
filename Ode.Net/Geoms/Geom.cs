using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public abstract class Geom : IDisposable
    {
        readonly dGeomID id;

        internal Geom(dGeomID geom)
        {
            id = geom;
            var handle = GCHandle.Alloc(this);
            NativeMethods.dGeomSetData(id, GCHandle.ToIntPtr(handle));
        }

        internal dGeomID Id
        {
            get { return id; }
        }

        internal static Geom FromIntPtr(IntPtr value)
        {
            if (value == IntPtr.Zero) return null;
            var handlePtr = NativeMethods.dGeomGetData(value);
            if (handlePtr == IntPtr.Zero) return null;
            var handle = GCHandle.FromIntPtr(handlePtr);
            return (Geom)handle.Target;
        }

        public Body Body
        {
            get { return Body.FromIntPtr(NativeMethods.dGeomGetBody(id)); }
            set { NativeMethods.dGeomSetBody(id, value != null ? value.Id : dBodyID.Null); }
        }

        public Vector3 Position
        {
            get
            {
                Vector3 position;
                NativeMethods.dGeomCopyPosition(id, out position);
                return position;
            }
            set
            {
                NativeMethods.dGeomSetPosition(id, value.X, value.Y, value.Z);
            }
        }

        public Matrix3 Rotation
        {
            get
            {
                Matrix3 rotation;
                NativeMethods.dGeomCopyRotation(id, out rotation);
                return rotation;
            }
            set
            {
                NativeMethods.dGeomSetRotation(id, ref value);
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                Quaternion quaternion;
                NativeMethods.dGeomGetQuaternion(id, out quaternion);
                return quaternion;
            }
            set
            {
                NativeMethods.dGeomSetQuaternion(id, ref value);
            }
        }

        public BoundingBox AxisAlignedBoundingBox
        {
            get
            {
                BoundingBox aabb;
                NativeMethods.dGeomGetAABB(id, out aabb);
                return aabb;
            }
        }

        public Space Space
        {
            get { return Space.FromIntPtr(NativeMethods.dGeomGetSpace(id)); }
        }

        public GeomClass Class
        {
            get { return NativeMethods.dGeomGetClass(id); }
        }

        public int CategoryBits
        {
            get { return (int)NativeMethods.dGeomGetCategoryBits(id); }
            set { NativeMethods.dGeomSetCategoryBits(id, (uint)value); }
        }

        public int CollideBits
        {
            get { return (int)NativeMethods.dGeomGetCollideBits(id); }
            set { NativeMethods.dGeomSetCollideBits(id, (uint)value); }
        }

        public bool Enabled
        {
            get { return NativeMethods.dGeomIsEnabled(id) != 0; }
            set
            {
                if (value) NativeMethods.dGeomEnable(id);
                else NativeMethods.dGeomDisable(id);
            }
        }

        public Vector3 OffsetPosition
        {
            get
            {
                Vector3 position;
                NativeMethods.dGeomCopyOffsetPosition(id, out position);
                return position;
            }
            set
            {
                NativeMethods.dGeomSetOffsetPosition(id, value.X, value.Y, value.Z);
            }
        }

        public Matrix3 OffsetRotation
        {
            get
            {
                Matrix3 rotation;
                NativeMethods.dGeomCopyOffsetRotation(id, out rotation);
                return rotation;
            }
            set
            {
                NativeMethods.dGeomSetOffsetRotation(id, ref value);
            }
        }

        public Quaternion OffsetQuaternion
        {
            get
            {
                Quaternion quaternion;
                NativeMethods.dGeomGetOffsetQuaternion(id, out quaternion);
                return quaternion;
            }
            set
            {
                NativeMethods.dGeomSetOffsetQuaternion(id, ref value);
            }
        }

        public bool IsOffset
        {
            get { return NativeMethods.dGeomIsOffset(id) != 0; }
        }

        /// <summary>
        /// Gets the position of the geom.
        /// </summary>
        /// <param name="position">The position of the geom.</param>
        public void GetPosition(out Vector3 position)
        {
            NativeMethods.dGeomCopyPosition(id, out position);
        }

        /// <summary>
        /// Sets the position of the geom.
        /// </summary>
        /// <param name="position">The position of the geom.</param>
        public void SetPosition(ref Vector3 position)
        {
            NativeMethods.dGeomSetPosition(id, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Gets the 3x3 rotation matrix of the geom.
        /// </summary>
        /// <param name="rotation">The 3x3 rotation matrix of the geom.</param>
        public void GetRotation(out Matrix3 rotation)
        {
            NativeMethods.dGeomCopyRotation(id, out rotation);
        }

        /// <summary>
        /// Sets the 3x3 rotation matrix of the geom.
        /// </summary>
        /// <param name="rotation">The 3x3 rotation matrix of the geom.</param>
        public void SetRotation(ref Matrix3 rotation)
        {
            NativeMethods.dGeomSetRotation(id, ref rotation);
        }

        /// <summary>
        /// Gets the orientation quaternion of the geom.
        /// </summary>
        /// <param name="quaternion">The orientation quaternion of the geom.</param>
        public void GetQuaternion(out Quaternion quaternion)
        {
            NativeMethods.dGeomGetQuaternion(id, out quaternion);
        }

        /// <summary>
        /// Sets the orientation quaternion of the geom.
        /// </summary>
        /// <param name="quaternion">The orientation quaternion of the geom.</param>
        public void SetQuaternion(ref Quaternion quaternion)
        {
            NativeMethods.dGeomSetQuaternion(id, ref quaternion);
        }

        /// <summary>
        /// Computes the global position of a point specified in geom relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in geom relative coordinates.</param>
        /// <param name="result">The position of the point in global coordinates.</param>
        public void GetRelativePointPosition(ref Vector3 point, out Vector3 result)
        {
            NativeMethods.dGeomGetRelPointPos(id, point.X, point.Y, point.Z, out result);
        }

        /// <summary>
        /// Computes the global position of a point specified in geom relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in geom relative coordinates.</param>
        /// <returns>The position of the point in global coordinates.</returns>
        public Vector3 GetRelativePointPosition(Vector3 point)
        {
            Vector3 result;
            GetRelativePointPosition(ref point, out result);
            return result;
        }

        /// <summary>
        /// Computes the geom relative position of a point specified in global coordinates.
        /// </summary>
        /// <param name="position">A point specified in global coordinates.</param>
        /// <param name="result">The position of the point in geom relative coordinates.</param>
        public void GetPositionRelativePoint(ref Vector3 position, out Vector3 result)
        {
            NativeMethods.dGeomGetPosRelPoint(id, position.X, position.Y, position.Z, out result);
        }

        /// <summary>
        /// Computes the geom relative position of a point specified in global coordinates.
        /// </summary>
        /// <param name="position">A point specified in global coordinates.</param>
        /// <returns>The position of the point in geom relative coordinates.</returns>
        public Vector3 GetPositionRelativePoint(Vector3 position)
        {
            Vector3 result;
            GetPositionRelativePoint(ref position, out result);
            return result;
        }

        /// <summary>
        /// Given a vector expressed in the geom's coordinate system, rotate it to the
        /// world coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the geom's coordinate system.</param>
        /// <param name="result">The rotated vector in the world coordinate system.</param>
        public void VectorToWorld(ref Vector3 vector, out Vector3 result)
        {
            NativeMethods.dGeomVectorToWorld(id, vector.X, vector.Y, vector.Z, out result);
        }

        /// <summary>
        /// Given a vector expressed in the geom's coordinate system, rotate it to the
        /// world coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the geom's coordinate system.</param>
        /// <returns>The rotated vector in the world coordinate system.</returns>
        public Vector3 VectorToWorld(Vector3 vector)
        {
            Vector3 result;
            VectorToWorld(ref vector, out result);
            return result;
        }

        /// <summary>
        /// Given a vector expressed in the world coordinate system, rotate it to the
        /// geom's coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the world coordinate system.</param>
        /// <param name="result">The rotated vector in the geom's coordinate system.</param>
        public void VectorFromWorld(ref Vector3 vector, out Vector3 result)
        {
            NativeMethods.dGeomVectorFromWorld(id, vector.X, vector.Y, vector.Z, out result);
        }

        /// <summary>
        /// Given a vector expressed in the world coordinate system, rotate it to the
        /// geom's coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the world coordinate system.</param>
        /// <returns>The rotated vector in the geom's coordinate system.</returns>
        public Vector3 VectorFromWorld(Vector3 vector)
        {
            Vector3 result;
            VectorFromWorld(ref vector, out result);
            return result;
        }

        /// <summary>
        /// Gets the local offset position of the geom from its body.
        /// </summary>
        /// <param name="position">The offset position of the geom.</param>
        public void GetOffsetPosition(out Vector3 position)
        {
            NativeMethods.dGeomCopyOffsetPosition(id, out position);
        }

        /// <summary>
        /// Sets the local offset position of the geom from its body.
        /// </summary>
        /// <param name="position">The offset position of the geom.</param>
        public void SetOffsetPosition(ref Vector3 position)
        {
            NativeMethods.dGeomSetOffsetPosition(id, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Gets the local offset rotation matrix of the geom from its body.
        /// </summary>
        /// <param name="rotation">The 3x3 offset rotation matrix of the geom.</param>
        public void GetOffsetRotation(out Matrix3 rotation)
        {
            NativeMethods.dGeomCopyOffsetRotation(id, out rotation);
        }

        /// <summary>
        /// Sets the local offset rotation matrix of the geom from its body.
        /// </summary>
        /// <param name="rotation">The 3x3 offset rotation matrix of the geom.</param>
        public void SetOffsetRotation(ref Matrix3 rotation)
        {
            NativeMethods.dGeomSetOffsetRotation(id, ref rotation);
        }

        /// <summary>
        /// Gets the local offset orientation quaternion of the geom from its body.
        /// </summary>
        /// <param name="quaternion">The offset orientation quaternion of the geom.</param>
        public void GetOffsetQuaternion(out Quaternion quaternion)
        {
            NativeMethods.dGeomGetOffsetQuaternion(id, out quaternion);
        }

        /// <summary>
        /// Sets the local offset orientation quaternion of the geom from its body.
        /// </summary>
        /// <param name="quaternion">The offset orientation quaternion of the geom.</param>
        public void SetOffsetQuaternion(ref Quaternion quaternion)
        {
            NativeMethods.dGeomSetOffsetQuaternion(id, ref quaternion);
        }

        /// <summary>
        /// Sets the offset position of the geom from its body such that the
        /// geom will be moved to the specified world coordinates.
        /// </summary>
        /// <param name="position">The offset position of the geom, in world coordinates.</param>
        public void SetOffsetWorldPosition(ref Vector3 position)
        {
            NativeMethods.dGeomSetOffsetWorldPosition(id, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Sets the offset rotation matrix of the geom from its body such that the
        /// geom will be oriented to the specified world rotation matrix.
        /// </summary>
        /// <param name="rotation">The 3x3 offset rotation matrix of the geom, in world frame.</param>
        public void SetOffsetWorldRotation(ref Matrix3 rotation)
        {
            NativeMethods.dGeomSetOffsetWorldRotation(id, ref rotation);
        }

        /// <summary>
        /// Sets the offset orientation quaternion of the geom from its body such that the
        /// geom will be oriented to the specified world quaternion.
        /// </summary>
        /// <param name="quaternion">The offset orientation quaternion of the geom, in world frame.</param>
        public void SetOffsetWorldQuaternion(ref Quaternion quaternion)
        {
            NativeMethods.dGeomSetOffsetWorldQuaternion(id, ref quaternion);
        }

        /// <summary>
        /// Clears any offset from the geom.
        /// </summary>
        public void ClearOffset()
        {
            NativeMethods.dGeomClearOffset(id);
        }

        /// <summary>
        /// Generates contact information between two specified geoms that potentially intersect.
        /// </summary>
        /// <param name="geom1">The first geom to test for contact.</param>
        /// <param name="geom2">The second geom to test for contact.</param>
        /// <param name="contacts">
        /// The array that will hold contact information. The length of the array determines
        /// the maximum number of contacts that can be generated.
        /// </param>
        /// <returns>
        /// The number of generated contact points, if the geoms intersect; otherwise, zero.
        /// </returns>
        public static int Collide(Geom geom1, Geom geom2, ContactGeom[] contacts)
        {
            return Collide(geom1, geom2, contacts, ContactGenerationFlags.None);
        }

        /// <summary>
        /// Generates contact information between two specified geoms that potentially intersect.
        /// </summary>
        /// <param name="geom1">The first geom to test for contact.</param>
        /// <param name="geom2">The second geom to test for contact.</param>
        /// <param name="contacts">
        /// The array that will hold contact information. The length of the array determines
        /// the maximum number of contacts that can be generated.
        /// </param>
        /// <param name="flags">Specifies contact generation options.</param>
        /// <returns>
        /// The number of generated contact points, if the geoms intersect; otherwise, zero.
        /// </returns>
        public static int Collide(Geom geom1, Geom geom2, ContactGeom[] contacts, ContactGenerationFlags flags)
        {
            if (geom1 == null)
            {
                throw new ArgumentNullException("geom1");
            }

            if (geom2 == null)
            {
                throw new ArgumentNullException("geom2");
            }

            if (contacts == null)
            {
                throw new ArgumentNullException("contacts");
            }

            flags |= (ContactGenerationFlags)((ushort)contacts.Length);
            return NativeMethods.dCollide(geom1.id, geom2.id, flags, contacts, ContactGeom.Size);
        }

        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                var handlePtr = NativeMethods.dGeomGetData(id);
                var handle = GCHandle.FromIntPtr(handlePtr);
                handle.Free();
                id.Close();
            }
        }
    }
}
