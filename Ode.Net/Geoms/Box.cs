using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Box : Geom
    {
        public Box(dReal lx, dReal ly, dReal lz)
            : this(null, lx, ly, lz)
        {
        }

        public Box(Space space, dReal lx, dReal ly, dReal lz)
            : base(NativeMethods.dCreateBox(space != null ? space.Id : dSpaceID.Null, lx, ly, lz))
        {
        }

        public Vector3 Lengths
        {
            get
            {
                Vector3 lengths;
                NativeMethods.dGeomBoxGetLengths(Id, out lengths);
                return lengths;
            }
            set
            {
                NativeMethods.dGeomBoxSetLengths(Id, value.X, value.Y, value.Z);
            }
        }

        public dReal PointDepth(dReal x, dReal y, dReal z)
        {
            return NativeMethods.dGeomBoxPointDepth(Id, x, y, z);
        }
    }
}
