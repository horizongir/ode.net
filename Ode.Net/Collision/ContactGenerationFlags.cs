using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Collision
{
    /// <summary>
    /// Specifies contact generation flags.
    /// </summary>
    [Flags]
    public enum ContactGenerationFlags
    {
        /// <summary>
        /// Specifies that no contact generation flags are active.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Specifies that no contact refinement should be used and any contacts
        /// found should be returned as soon as possible.
        /// </summary>
        ContactsUnimportant = unchecked((int)0x80000000)
    }
}
