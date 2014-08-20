using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    [Flags]
    public enum ContactGenerationFlags
    {
        None = 0x0,
        ContactsUnimportant = unchecked((int)0x80000000)
    }
}
