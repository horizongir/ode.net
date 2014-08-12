using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net
{
    /// <summary>
    /// Represents a rigid body.
    /// </summary>
    public class Body : IDisposable
    {
        int disposed;
        readonly dBodyID id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Body"/> class on the
        /// specified world.
        /// </summary>
        /// <param name="world">The world on which to place the body.</param>
        public Body(World world)
        {
            id = NativeMethods.dBodyCreate(world.Id);
            var handle = GCHandle.Alloc(this);
            NativeMethods.dBodySetData(id, GCHandle.ToIntPtr(handle));
        }

        /// <summary>
        /// Gets or sets the auto-disable linear velocity threshold for the body.
        /// </summary>
        public dReal AutoDisableLinearThreshold
        {
            get { return NativeMethods.dBodyGetAutoDisableLinearThreshold(id); }
            set { NativeMethods.dBodySetAutoDisableLinearThreshold(id, value); }
        }

        /// <summary>
        /// Gets or sets the auto-disable angular velocity threshold for the body.
        /// </summary>
        public dReal AutoDisableAngularThreshold
        {
            get { return NativeMethods.dBodyGetAutoDisableAngularThreshold(id); }
            set { NativeMethods.dBodySetAutoDisableAngularThreshold(id, value); }
        }

        /// <summary>
        /// Gets or sets the auto-disable average velocity sample count for the body.
        /// </summary>
        public int AutoDisableAverageSamplesCount
        {
            get { return NativeMethods.dBodyGetAutoDisableAverageSamplesCount(id); }
            set { NativeMethods.dBodySetAutoDisableAverageSamplesCount(id, (uint)value); }
        }

        /// <summary>
        /// Gets or sets the number of simulation steps the body has to be idle for
        /// in order to automatically disable itself.
        /// </summary>
        public int AutoDisableSteps
        {
            get { return NativeMethods.dBodyGetAutoDisableSteps(id); }
            set { NativeMethods.dBodySetAutoDisableSteps(id, value); }
        }

        /// <summary>
        /// Gets or sets the amount of simulation time the body has to be idle for
        /// in order to automatically disable itself.
        /// </summary>
        public dReal AutoDisableTime
        {
            get { return NativeMethods.dBodyGetAutoDisableTime(id); }
            set { NativeMethods.dBodySetAutoDisableTime(id, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the body should automatically
        /// disable itself when it has been idle for some specified period of time.
        /// </summary>
        public bool AutoDisable
        {
            get { return NativeMethods.dBodyGetAutoDisableFlag(id) != 0; }
            set { NativeMethods.dBodySetAutoDisableFlag(id, value ? 1 : 0); }
        }

        /// <summary>
        /// Gets or sets the object that contains data about the rigid body.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the position of the rigid body.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                Vector3 position;
                NativeMethods.dBodyCopyPosition(id, out position);
                return position;
            }
            set
            {
                NativeMethods.dBodySetPosition(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the 3x3 rotation matrix of the rigid body.
        /// </summary>
        public Matrix3 Rotation
        {
            get
            {
                Matrix3 rotation;
                NativeMethods.dBodyCopyRotation(id, out rotation);
                return rotation;
            }
            set
            {
                NativeMethods.dBodySetRotation(id, ref value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation quaternion of the rigid body.
        /// </summary>
        public Quaternion Quaternion
        {
            get
            {
                Quaternion quaternion;
                NativeMethods.dBodyCopyQuaternion(id, out quaternion);
                return quaternion;
            }
            set
            {
                NativeMethods.dBodySetQuaternion(id, ref value);
            }
        }

        /// <summary>
        /// Gets or sets the linear velocity of the rigid body.
        /// </summary>
        public Vector3 LinearVelocity
        {
            get
            {
                var linearVelPtr = NativeMethods.dBodyGetLinearVel(id);
                return utils.PtrToVector3(linearVelPtr);
            }
            set
            {
                NativeMethods.dBodySetLinearVel(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the angular velocity of the rigid body.
        /// </summary>
        public Vector3 AngularVelocity
        {
            get
            {
                var angularVelPtr = NativeMethods.dBodyGetAngularVel(id);
                return utils.PtrToVector3(angularVelPtr);
            }
            set
            {
                NativeMethods.dBodySetAngularVel(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the mass of the rigid body.
        /// </summary>
        public Mass Mass
        {
            get
            {
                Mass mass;
                NativeMethods.dBodyGetMass(id, out mass);
                return mass;
            }
            set
            {
                NativeMethods.dBodySetMass(id, ref value);
            }
        }

        /// <summary>
        /// Gets or sets the current accumulated force vector.
        /// </summary>
        public Vector3 Force
        {
            get
            {
                var forcePtr = NativeMethods.dBodyGetForce(id);
                return utils.PtrToVector3(forcePtr);
            }
            set
            {
                NativeMethods.dBodySetForce(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the current accumulated torque vector.
        /// </summary>
        public Vector3 Torque
        {
            get
            {
                var torquePtr = NativeMethods.dBodyGetTorque(id);
                return utils.PtrToVector3(torquePtr);
            }
            set
            {
                NativeMethods.dBodySetTorque(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the mode in which the body's orientation is updated at each time step.
        /// </summary>
        public RotationMode FiniteRotationMode
        {
            get { return NativeMethods.dBodyGetFiniteRotationMode(id); }
            set { NativeMethods.dBodySetFiniteRotationMode(id, value); }
        }

        /// <summary>
        /// Gets or sets the finite rotation axis for the rigid body.
        /// </summary>
        public Vector3 FiniteRotationAxis
        {
            get
            {
                Vector3 axis;
                NativeMethods.dBodyGetFiniteRotationAxis(id, out axis);
                return axis;
            }
            set
            {
                NativeMethods.dBodySetFiniteRotationAxis(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Sets the auto-disable parameters to those set as default for the world.
        /// </summary>
        public void SetAutoDisableDefaults()
        {
            NativeMethods.dBodySetAutoDisableDefaults(id);
        }

        /// <summary>
        /// Gets the position of the rigid body.
        /// </summary>
        /// <param name="position">The position of the rigid body.</param>
        public void GetPosition(out Vector3 position)
        {
            NativeMethods.dBodyCopyPosition(id, out position);
        }

        /// <summary>
        /// Sets the position of the rigid body.
        /// </summary>
        /// <param name="position">The position of the rigid body.</param>
        public void SetPosition(ref Vector3 position)
        {
            NativeMethods.dBodySetPosition(id, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Gets the 3x3 rotation matrix of the rigid body.
        /// </summary>
        /// <param name="rotation">The 3x3 rotation matrix of the rigid body.</param>
        public void GetRotation(out Matrix3 rotation)
        {
            NativeMethods.dBodyCopyRotation(id, out rotation);
        }

        /// <summary>
        /// Sets the 3x3 rotation matrix of the rigid body.
        /// </summary>
        /// <param name="rotation">The 3x3 rotation matrix of the rigid body.</param>
        public void SetRotation(ref Matrix3 rotation)
        {
            NativeMethods.dBodySetRotation(id, ref rotation);
        }

        /// <summary>
        /// Gets the orientation quaternion of the rigid body.
        /// </summary>
        /// <param name="quaternion">The orientation quaternion of the rigid body.</param>
        public void GetQuaternion(out Quaternion quaternion)
        {
            NativeMethods.dBodyCopyQuaternion(id, out quaternion);
        }

        /// <summary>
        /// Sets the orientation quaternion of the rigid body.
        /// </summary>
        /// <param name="quaternion">The orientation quaternion of the rigid body.</param>
        public void SetQuaternion(ref Quaternion quaternion)
        {
            NativeMethods.dBodySetQuaternion(id, ref quaternion);
        }

        /// <summary>
        /// Gets the linear velocity of the rigid body.
        /// </summary>
        /// <param name="linearVelocity">The linear velocity of the rigid body.</param>
        public void GetLinearVelocity(out Vector3 linearVelocity)
        {
            var linearVelPtr = NativeMethods.dBodyGetLinearVel(id);
            utils.PtrToVector3(linearVelPtr, out linearVelocity);
        }

        /// <summary>
        /// Sets the linear velocity of the rigid body.
        /// </summary>
        /// <param name="linearVelocity">The linear velocity of the rigid body.</param>
        public void SetLinearVelocity(ref Vector3 linearVelocity)
        {
            NativeMethods.dBodySetLinearVel(id, linearVelocity.X, linearVelocity.Y, linearVelocity.Z);
        }

        /// <summary>
        /// Gets the angular velocity of the rigid body.
        /// </summary>
        /// <param name="angularVelocity">The angular velocity of the rigid body.</param>
        public void GetAngularVelocity(out Vector3 angularVelocity)
        {
            var angularVelPtr = NativeMethods.dBodyGetAngularVel(id);
            utils.PtrToVector3(angularVelPtr, out angularVelocity);
        }

        /// <summary>
        /// Sets the angular velocity of the rigid body.
        /// </summary>
        /// <param name="angularVelocity">The angular velocity of the rigid body.</param>
        public void SetAngularVelocity(ref Vector3 angularVelocity)
        {
            NativeMethods.dBodySetAngularVel(id, angularVelocity.X, angularVelocity.Y, angularVelocity.Z);
        }

        /// <summary>
        /// Add force at the center of mass of the body.
        /// </summary>
        /// <param name="force">The force vector in the world coordinate system.</param>
        public void AddForce(Vector3 force)
        {
            NativeMethods.dBodyAddForce(id, force.X, force.Y, force.Z);
        }

        /// <summary>
        /// Add torque at the center of mass of the body.
        /// </summary>
        /// <param name="torque">The torque vector in the world coordinate system.</param>
        public void AddTorque(Vector3 torque)
        {
            NativeMethods.dBodyAddTorque(id, torque.X, torque.Y, torque.Z);
        }

        /// <summary>
        /// Add force at the center of mass of the body.
        /// </summary>
        /// <param name="force">The force vector in the body's coordinate system.</param>
        public void AddRelativeForce(Vector3 force)
        {
            NativeMethods.dBodyAddRelForce(id, force.X, force.Y, force.Z);
        }

        /// <summary>
        /// Add torque at the center of mass of the body.
        /// </summary>
        /// <param name="torque">The torque vector in the body's coordinate system.</param>
        public void AddRelativeTorque(Vector3 torque)
        {
            NativeMethods.dBodyAddRelTorque(id, torque.X, torque.Y, torque.Z);
        }

        /// <summary>
        /// Add force to the body applied at the specified position.
        /// </summary>
        /// <param name="force">The force vector in the world coordinate system.</param>
        /// <param name="position">The point of application in global coordinates.</param>
        public void AddForceAtPosition(Vector3 force, Vector3 position)
        {
            NativeMethods.dBodyAddForceAtPos(
                id, force.X, force.Y, force.Z,
                position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Add force to the body applied at the specified position.
        /// </summary>
        /// <param name="force">The force vector in the world coordinate system.</param>
        /// <param name="position">The point of application in body relative coordinates.</param>
        public void AddForceAtRelativePosition(Vector3 force, Vector3 position)
        {
            NativeMethods.dBodyAddForceAtRelPos(
                id, force.X, force.Y, force.Z,
                position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Add force to the body applied at the specified position.
        /// </summary>
        /// <param name="force">The force vector in the body's coordinate system.</param>
        /// <param name="position">The point of application in global coordinates.</param>
        public void AddRelativeForceAtPosition(Vector3 force, Vector3 position)
        {
            NativeMethods.dBodyAddRelForceAtPos(
                id, force.X, force.Y, force.Z,
                position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Add force to the body applied at the specified position.
        /// </summary>
        /// <param name="force">The force vector in the body's coordinate system.</param>
        /// <param name="position">The point of application in body relative coordinates.</param>
        public void AddRelativeForceAtRelativePosition(Vector3 force, Vector3 position)
        {
            NativeMethods.dBodyAddRelForceAtRelPos(
                id, force.X, force.Y, force.Z,
                position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Gets the current accumulated force vector.
        /// </summary>
        /// <param name="force">The current accumulated force vector.</param>
        public void GetForce(out Vector3 force)
        {
            var forcePtr = NativeMethods.dBodyGetForce(id);
            utils.PtrToVector3(forcePtr, out force);
        }

        /// <summary>
        /// Sets the current accumulated force vector.
        /// </summary>
        /// <param name="force">The current accumulated force vector.</param>
        public void SetForce(ref Vector3 force)
        {
            NativeMethods.dBodySetForce(id, force.X, force.Y, force.Z);
        }

        /// <summary>
        /// Gets the current accumulated torque vector.
        /// </summary>
        /// <param name="torque">The current accumulated torque vector.</param>
        public void GetTorque(out Vector3 torque)
        {
            var torquePtr = NativeMethods.dBodyGetTorque(id);
            utils.PtrToVector3(torquePtr, out torque);
        }

        /// <summary>
        /// Sets the current accumulated torque vector.
        /// </summary>
        /// <param name="torque">The current accumulated torque vector.</param>
        public void SetTorque(ref Vector3 torque)
        {
            NativeMethods.dBodySetTorque(id, torque.X, torque.Y, torque.Z);
        }

        /// <summary>
        /// Computes the global position of a point specified in body relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in body relative coordinates.</param>
        /// <param name="result">The position of the point in global coordinates.</param>
        public void GetRelativePointPosition(ref Vector3 point, out Vector3 result)
        {
            NativeMethods.dBodyGetRelPointPos(id, point.X, point.Y, point.Z, out result);
        }

        /// <summary>
        /// Computes the global position of a point specified in body relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in body relative coordinates.</param>
        /// <returns>The position of the point in global coordinates.</returns>
        public Vector3 GetRelativePointPosition(Vector3 point)
        {
            Vector3 result;
            GetRelativePointPosition(ref point, out result);
            return result;
        }

        /// <summary>
        /// Computes the velocity of a point specified in body relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in body relative coordinates.</param>
        /// <param name="result">The velocity of the point.</param>
        public void GetRelativePointVelocity(ref Vector3 point, out Vector3 result)
        {
            NativeMethods.dBodyGetRelPointVel(id, point.X, point.Y, point.Z, out result);
        }

        /// <summary>
        /// Computes the velocity of a point specified in body relative coordinates.
        /// </summary>
        /// <param name="point">A point specified in body relative coordinates.</param>
        /// <returns>The velocity of the point.</returns>
        public Vector3 GetRelativePointVelocity(Vector3 point)
        {
            Vector3 result;
            GetRelativePointVelocity(ref point, out result);
            return result;
        }

        /// <summary>
        /// Computes the velocity of a point specified in global coordinates.
        /// </summary>
        /// <param name="point">A point specified in global coordinates.</param>
        /// <param name="result">The velocity of the point.</param>
        public void GetPointVelocity(ref Vector3 point, out Vector3 result)
        {
            NativeMethods.dBodyGetPointVel(id, point.X, point.Y, point.Z, out result);
        }

        /// <summary>
        /// Computes the velocity of a point specified in global coordinates.
        /// </summary>
        /// <param name="point">A point specified in global coordinates.</param>
        /// <returns>The velocity of the point.</returns>
        public Vector3 GetPointVelocity(Vector3 point)
        {
            Vector3 result;
            GetPointVelocity(ref point, out result);
            return result;
        }

        /// <summary>
        /// Computes the body relative position of a point specified in global coordinates.
        /// </summary>
        /// <param name="position">A point specified in global coordinates.</param>
        /// <param name="result">The position of the point in body relative coordinates.</param>
        public void GetPositionRelativePoint(ref Vector3 position, out Vector3 result)
        {
            NativeMethods.dBodyGetPosRelPoint(id, position.X, position.Y, position.Z, out result);
        }

        /// <summary>
        /// Computes the body relative position of a point specified in global coordinates.
        /// </summary>
        /// <param name="position">A point specified in global coordinates.</param>
        /// <returns>The position of the point in body relative coordinates.</returns>
        public Vector3 GetPositionRelativePoint(Vector3 position)
        {
            Vector3 result;
            GetPositionRelativePoint(ref position, out result);
            return result;
        }

        /// <summary>
        /// Given a vector expressed in the body's coordinate system, rotate it to the
        /// world coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the body's coordinate system.</param>
        /// <param name="result">The rotated vector in the world coordinate system.</param>
        public void VectorToWorld(ref Vector3 vector, out Vector3 result)
        {
            NativeMethods.dBodyVectorToWorld(id, vector.X, vector.Y, vector.Z, out result);
        }

        /// <summary>
        /// Given a vector expressed in the body's coordinate system, rotate it to the
        /// world coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the body's coordinate system.</param>
        /// <returns>The rotated vector in the world coordinate system.</returns>
        public Vector3 VectorToWorld(Vector3 vector)
        {
            Vector3 result;
            VectorToWorld(ref vector, out result);
            return result;
        }

        /// <summary>
        /// Given a vector expressed in the world coordinate system, rotate it to the
        /// body's coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the world coordinate system.</param>
        /// <param name="result">The rotated vector in the body's coordinate system.</param>
        public void VectorFromWorld(ref Vector3 vector, out Vector3 result)
        {
            NativeMethods.dBodyVectorFromWorld(id, vector.X, vector.Y, vector.Z, out result);
        }

        /// <summary>
        /// Given a vector expressed in the world coordinate system, rotate it to the
        /// body's coordinate system.
        /// </summary>
        /// <param name="vector">The vector to rotate in the world coordinate system.</param>
        /// <returns>The rotated vector in the body's coordinate system.</returns>
        public Vector3 VectorFromWorld(Vector3 vector)
        {
            Vector3 result;
            VectorFromWorld(ref vector, out result);
            return result;
        }

        /// <summary>
        /// Sets the finite rotation axis for the rigid body.
        /// </summary>
        /// <param name="axis">The finite rotation axis for the rigid body.</param>
        public void SetFiniteRotationAxis(ref Vector3 axis)
        {
            NativeMethods.dBodySetFiniteRotationAxis(id, axis.X, axis.Y, axis.Z);
        }

        /// <summary>
        /// Gets the finite rotation axis for the rigid body.
        /// </summary>
        /// <param name="axis">The finite rotation axis for the rigid body.</param>
        public void GetFiniteRotationAxis(out Vector3 axis)
        {
            NativeMethods.dBodyGetFiniteRotationAxis(id, out axis);
        }

        /// <summary>
        /// Destroys the rigid body.
        /// </summary>
        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref disposed, 1, 0) == 0)
            {
                var handlePtr = NativeMethods.dBodyGetData(id);
                var handle = GCHandle.FromIntPtr(handlePtr);
                handle.Free();
                id.Close();
            }
        }
    }
}
