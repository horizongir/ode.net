using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public sealed class QuadTreeSpace : Space
    {
        public QuadTreeSpace(Vector3 center, Vector3 extents, int depth)
            : this(null, center, extents, depth)
        {
        }

        public QuadTreeSpace(Space space, Vector3 center, Vector3 extents, int depth)
            : base(NativeMethods.dQuadTreeSpaceCreate(space != null ? space.Id : dSpaceID.Null,
                                                      ref center, ref extents, depth))
        {
        }
    }
}
