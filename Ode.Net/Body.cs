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
