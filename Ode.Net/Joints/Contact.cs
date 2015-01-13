using Ode.Net.Geoms;
using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    /// <summary>
    /// Represents a joint used to prevent two bodies from inter-penetrating
    /// at a contact point.
    /// </summary>
    public sealed class Contact : Joint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="world">The world on which to place the joint.</param>
        /// <param name="contact">
        /// A structure containing information about the contact point and
        /// colliding surfaces.
        /// </param>
        public Contact(World world, ContactInfo contact)
            : this(world, contact, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="world">The world on which to place the joint.</param>
        /// <param name="contact">
        /// A structure containing information about the contact point and
        /// colliding surfaces.
        /// </param>
        /// <param name="group">The joint group that will contain the joint.</param>
        public Contact(World world, ContactInfo contact, JointGroup group)
            : base(NativeMethods.dJointCreateContact(world.Id, dJointGroupID.Null, ref contact), group)
        {
        }
    }
}
