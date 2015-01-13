using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents the properties of colliding surfaces.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceParameters
    {
        /// <summary>
        /// Specifies the contact modes for the surface.
        /// </summary>
        public ContactModes Mode;

        /// <summary>
        /// Specifies the Coulomb friction coefficient of the surface.
        /// </summary>
        /// <remarks>
        /// This must be in the range 0 to Infinity. 0 results in a frictionless
        /// contact, and dInfinity results in a contact that never slips. Note
        /// that frictionless contacts are less time consuming to compute than
        /// ones with friction, and infinite friction contacts can be cheaper
        /// than contacts with finite friction. This must always be set.
        /// </remarks>
        public dReal Mu;

        /// <summary>
        /// Specifies the optional Coulomb friction coefficient for friction direction 2.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Mu2;

        /// <summary>
        /// Specifies the rolling friction coefficient around direction 1.
        /// </summary>
        public dReal Rho;

        /// <summary>
        /// Specifies the rolling friction coefficient around direction 2.
        /// </summary>
        public dReal Rho2;

        /// <summary>
        /// Specifies the rolling friction coefficient around the normal direction.
        /// </summary>
        public dReal RhoN;

        /// <summary>
        /// Specifies the restitution parameter for the surface. 0 means the surface is
        /// not bouncy at all, 1 is maximum bouncyness.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Bounce;

        /// <summary>
        /// Specifies the minimum incoming velocity necessary for bounce.
        /// </summary>
        /// <remarks>
        /// Incoming velocities below this will effectively have a bounce
        /// parameter of 0. This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal BounceVelocity;

        /// <summary>
        /// Specifies the contact normal ``softness'' parameter.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal SoftErp;

        /// <summary>
        /// Specifies the contact normal ``softness'' parameter.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal SoftCfm;

        /// <summary>
        /// Specifies the surface velocity in friction direction 1.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Motion1;

        /// <summary>
        /// Specifies the surface velocity in friction direction 2.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Motion2;

        /// <summary>
        /// Specifies the surface velocity in the direction of the contact normal.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal MotionN;

        /// <summary>
        /// Specifies the coefficient of force-dependent-slip (FDS) for friction direction 1.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Slip1;

        /// <summary>
        /// Specifies the coefficient of force-dependent-slip (FDS) for friction direction 2.
        /// </summary>
        /// <remarks>
        /// This is only used if the corresponding mode is set.
        /// </remarks>
        public dReal Slip2;
    }
}
