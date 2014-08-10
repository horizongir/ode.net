using Ode.Net.Native;
using OpenTK;
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
    public class Body : IDisposable
    {
        int disposed;
        readonly dBodyID id;

        public Body(World world)
        {
            id = NativeMethods.dBodyCreate(world.Id);
            var handle = GCHandle.Alloc(this);
            NativeMethods.dBodySetData(id, GCHandle.ToIntPtr(handle));
        }

        public dReal AutoDisableLinearThreshold
        {
            get { return NativeMethods.dBodyGetAutoDisableLinearThreshold(id); }
            set { NativeMethods.dBodySetAutoDisableLinearThreshold(id, value); }
        }

        public dReal AutoDisableAngularThreshold
        {
            get { return NativeMethods.dBodyGetAutoDisableAngularThreshold(id); }
            set { NativeMethods.dBodySetAutoDisableAngularThreshold(id, value); }
        }

        public int AutoDisableAverageSamplesCount
        {
            get { return NativeMethods.dBodyGetAutoDisableAverageSamplesCount(id); }
            set { NativeMethods.dBodySetAutoDisableAverageSamplesCount(id, (uint)value); }
        }

        public int AutoDisableSteps
        {
            get { return NativeMethods.dBodyGetAutoDisableSteps(id); }
            set { NativeMethods.dBodySetAutoDisableSteps(id, value); }
        }

        public dReal AutoDisableTime
        {
            get { return NativeMethods.dBodyGetAutoDisableTime(id); }
            set { NativeMethods.dBodySetAutoDisableTime(id, value); }
        }

        public bool AutoDisableFlag
        {
            get { return NativeMethods.dBodyGetAutoDisableFlag(id) != 0; }
            set { NativeMethods.dBodySetAutoDisableFlag(id, value ? 1 : 0); }
        }

        public object Data { get; set; }

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
                //NativeMethods.dBodySetMass(id, ref value.Value);
            }
        }

        public void SetAutoDisableDefaults()
        {
            NativeMethods.dBodySetAutoDisableDefaults(id);
        }

        public void GetPosition(out Vector3 position)
        {
            NativeMethods.dBodyCopyPosition(id, out position);
        }

        public void SetPosition(ref Vector3 position)
        {
            NativeMethods.dBodySetPosition(id, position.X, position.Y, position.Z);
        }

        public void GetRotation(out Matrix3 rotation)
        {
            NativeMethods.dBodyCopyRotation(id, out rotation);
        }

        public void SetRotation(ref Matrix3 rotation)
        {
            NativeMethods.dBodySetRotation(id, ref rotation);
        }

        public void GetQuaternion(out Quaternion quaternion)
        {
            NativeMethods.dBodyCopyQuaternion(id, out quaternion);
        }

        public void SetQuaternion(ref Quaternion quaternion)
        {
            NativeMethods.dBodySetQuaternion(id, ref quaternion);
        }

        public void GetLinearVelocity(out Vector3 linearVelocity)
        {
            var linearVelPtr = NativeMethods.dBodyGetLinearVel(id);
            utils.PtrToVector3(linearVelPtr, out linearVelocity);
        }

        public void SetLinearVelocity(ref Vector3 linearVelocity)
        {
            NativeMethods.dBodySetLinearVel(id, linearVelocity.X, linearVelocity.Y, linearVelocity.Z);
        }

        public void GetAngularVelocity(out Vector3 angularVelocity)
        {
            var angularVelPtr = NativeMethods.dBodyGetAngularVel(id);
            utils.PtrToVector3(angularVelPtr, out angularVelocity);
        }

        public void SetAngularVelocity(ref Vector3 angularVelocity)
        {
            NativeMethods.dBodySetAngularVel(id, angularVelocity.X, angularVelocity.Y, angularVelocity.Z);
        }

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
