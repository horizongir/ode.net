using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Plane : Geom
    {
        public Plane(dReal a, dReal b, dReal c, dReal d)
            : this(null, a, b, c, d)
        {
        }

        public Plane(Space space, dReal a, dReal b, dReal c, dReal d)
            : base(NativeMethods.dCreatePlane(space != null ? space.Id : dSpaceID.Null, a, b, c, d))
        {
        }

        public Vector4 Parameters
        {
            get
            {
                Vector4 parameters;
                NativeMethods.dGeomPlaneGetParams(Id, out parameters);
                return parameters;
            }
            set
            {
                NativeMethods.dGeomPlaneSetParams(Id, value.X, value.Y, value.Z, value.W);
            }
        }

        public dReal PointDepth(dReal x, dReal y, dReal z)
        {
            return NativeMethods.dGeomPlanePointDepth(Id, x, y, z);
        }
    }
}
