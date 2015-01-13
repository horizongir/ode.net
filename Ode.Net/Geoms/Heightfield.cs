using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public sealed class Heightfield : Geom
    {
        HeightfieldData data;

        public Heightfield(HeightfieldData data, bool placeable)
            : this(null, data, placeable)
        {
        }

        public Heightfield(Space space, HeightfieldData data, bool placeable)
            : base(NativeMethods.dCreateHeightfield(space != null ? space.Id : dSpaceID.Null, data.Id, placeable ? 1 : 0))
        {
            this.data = data;
        }

        public HeightfieldData Data
        {
            get { return data; }
            set
            {
                data = value;
                NativeMethods.dGeomHeightfieldSetHeightfieldData(Id, value.Id);
            }
        }
    }
}
