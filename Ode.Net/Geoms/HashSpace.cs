using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public sealed class HashSpace : Space
    {
        public HashSpace()
            : this(null)
        {
        }

        public HashSpace(Space space)
            : base(NativeMethods.dHashSpaceCreate(space != null ? space.Id : dSpaceID.Null))
        {
        }

        public int MinLevel
        {
            get
            {
                int minLevel, maxLevel;
                NativeMethods.dHashSpaceGetLevels(Id, out minLevel, out maxLevel);
                return minLevel;
            }
            set
            {
                int minlevel, maxlevel;
                NativeMethods.dHashSpaceGetLevels(Id, out minlevel, out maxlevel);
                NativeMethods.dHashSpaceSetLevels(Id, value, maxlevel);
            }
        }

        public int MaxLevel
        {
            get
            {
                int minLevel, maxLevel;
                NativeMethods.dHashSpaceGetLevels(Id, out minLevel, out maxLevel);
                return maxLevel;
            }
            set
            {
                int minlevel, maxlevel;
                NativeMethods.dHashSpaceGetLevels(Id, out minlevel, out maxlevel);
                NativeMethods.dHashSpaceSetLevels(Id, minlevel, value);
            }
        }
    }
}
