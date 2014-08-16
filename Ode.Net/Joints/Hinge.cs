using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Joints
{
    /// <summary>
    /// Represents a hinge joint.
    /// </summary>
    public sealed class Hinge : Joint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hinge"/> class.
        /// </summary>
        /// <param name="world">The world on which to place the joint.</param>
        public Hinge(World world)
            : this(world, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hinge"/> class on
        /// the specified <see cref="JointGroup"/>.
        /// </summary>
        /// <param name="world">The world on which to place the joint.</param>
        /// <param name="group">The joint group that will contain the joint.</param>
        public Hinge(World world, JointGroup group)
            : base(NativeMethods.dJointCreateHinge(world.Id, dJointGroupID.Null))
        {
            if (group != null)
            {
                group.Add(this);
            }
        }

        /// <summary>
        /// Gets or sets the joint main anchor point.
        /// </summary>
        public Vector3 Anchor
        {
            get
            {
                Vector3 anchor;
                NativeMethods.dJointGetHingeAnchor(id, out anchor);
                return anchor;
            }
            set
            {
                NativeMethods.dJointSetHingeAnchor(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets the joint anchor point on the second body.
        /// </summary>
        public Vector3 Anchor2
        {
            get
            {
                Vector3 anchor;
                NativeMethods.dJointGetHingeAnchor2(id, out anchor);
                return anchor;
            }
        }

        /// <summary>
        /// Gets or sets the hinge rotation axis.
        /// </summary>
        public Vector3 Axis
        {
            get
            {
                Vector3 axis;
                NativeMethods.dJointGetHingeAxis(id, out axis);
                return axis;
            }
            set
            {
                NativeMethods.dJointSetHingeAxis(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets the angle measured between the two bodies with respect
        /// to the hinge axis.
        /// </summary>
        public dReal Angle
        {
            get { return NativeMethods.dJointGetHingeAngle(id); }
        }

        /// <summary>
        /// Gets the hinge angle time derivative.
        /// </summary>
        public dReal AngleRate
        {
            get { return NativeMethods.dJointGetHingeAngleRate(id); }
        }

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

        /// <summary>
        /// Sets the hinge anchor point with a relative displacement vector.
        /// </summary>
        /// <param name="anchor">The hinge anchor point, in world frame coordinates.</param>
        /// <param name="displacement">
        /// The relative displacement vector between the passive body and the anchor.
        /// </param>
        public void SetAnchorDelta(Vector3 anchor, Vector3 displacement)
        {
            NativeMethods.dJointSetHingeAnchorDelta(
                id, anchor.X, anchor.Y, anchor.Z,
                displacement.X, displacement.Y, displacement.Z);
        }

        /// <summary>
        /// Sets the hinge axis as if the two bodies were already apart by the
        /// specified angle.
        /// </summary>
        /// <param name="axis">The hinge axis, in world frame coordinates.</param>
        /// <param name="angle">
        /// The angle for the offset of the relative orientation between the two bodies.
        /// The rotation is specified about the new hinge axis.
        /// </param>
        public void SetAxisOffset(Vector3 axis, dReal angle)
        {
            NativeMethods.dJointSetHingeAxisOffset(id, axis.X, axis.Y, axis.Z, angle);
        }

        /// <summary>
        /// Applies the specified torque about the hinge axis.
        /// </summary>
        /// <param name="torque">The torque value to be applied.</param>
        public void AddTorque(dReal torque)
        {
            NativeMethods.dJointAddHingeTorque(id, torque);
        }
    }
}
