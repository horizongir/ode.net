using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Joints
{
    public abstract class JointLimitMotor
    {
        readonly dJointID id;

        internal JointLimitMotor(Joint joint)
        {
            id = joint.id;
        }

        internal abstract dReal GetParam(dJointID id, dJointParam parameter);

        internal abstract void SetParam(dJointID id, dJointParam parameter, dReal value);

        /// <summary>
        /// Gets or sets the low stop angle or position.
        /// </summary>
        /// <remarks>
        /// Setting this to -Infinity (the default value) turns off the low stop.
        /// For rotational joints, this stop must be greater than -pi to be effective.
        /// </remarks>
        public dReal LowStop
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamLoStop); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamLoStop, value); }
        }

        /// <summary>
        /// Gets or sets the high stop angle or position.
        /// </summary>
        /// <remarks>
        /// Setting this to dInfinity (the default value) turns off the high stop.
        /// For rotational joints, this stop must be less than pi to be effective.
        /// If the high stop is less than the low stop then both stops will be ineffective.
        /// </remarks>
        public dReal HighStop
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamHiStop); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamHiStop, value); }
        }

        /// <summary>
        /// Gets or sets the desired motor velocity (this will be an angular or linear velocity).
        /// </summary>
        public dReal Velocity
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamVel); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamVel, value); }
        }

        /// <summary>
        /// Gets or sets the maximum force or torque that the motor will use to achieve the
        /// desired velocity.
        /// </summary>
        /// <remarks>
        /// This must always be greater than or equal to zero. Setting this to
        /// zero (the default value) turns off the motor.
        /// </remarks>
        public dReal MaxForce
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamFMax); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamFMax, value); }
        }

        /// <summary>
        /// Gets or sets a scale factor to prevent excess force being applied at the stops.
        /// </summary>
        /// <remarks>
        /// It should have a value between zero and one (the default value).
        /// If the jumping motion is too visible in a joint, the value can be
        /// reduced. Making this value too small can prevent the motor from
        /// being able to move the joint away from a stop.
        /// </remarks>
        public dReal FudgeFactor
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamFudgeFactor); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamFudgeFactor, value); }
        }

        /// <summary>
        /// Gets or sets a value controlling the restitution strength at the stops.
        /// </summary>
        /// <remarks>
        /// This is a restitution parameter in the range 0..1. 0 means the
        /// stops are not bouncy at all, 1 means maximum bounciness.
        /// </remarks>
        public dReal Bounce
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamBounce); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamBounce, value); }
        }

        /// <summary>
        /// Gets or sets the constraint force mixing value used when not at a stop.
        /// </summary>
        public dReal Cfm
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamCFM); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamCFM, value); }
        }

        /// <summary>
        /// Gets or sets the error reduction parameter used at the stops.
        /// </summary>
        public dReal StopErp
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamStopERP); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamStopERP, value); }
        }

        /// <summary>
        /// Gets or sets the constraint force mixing value used at the stops.
        /// </summary>
        /// <remarks>
        /// Together with the ERP value this can be used to get spongy or soft stops.
        /// Note that this is intended for unpowered joints, it does not really work
        /// as expected when a powered joint reaches its limit.
        /// </remarks>
        public dReal StopCfm
        {
            get { return NativeMethods.dJointGetHingeParam(id, dJointParam.dParamStopCFM); }
            set { NativeMethods.dJointSetHingeParam(id, dJointParam.dParamStopCFM, value); }
        }
    }
}
