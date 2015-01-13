using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Sphere : Geom
    {
        public Sphere(dReal radius)
            : this(null, radius)
        {
        }

        public Sphere(Space space, dReal radius)
            : base(NativeMethods.dCreateSphere(space != null ? space.Id : dSpaceID.Null, radius))
        {
        }

        public dReal Radius
        {
            get { return NativeMethods.dGeomSphereGetRadius(Id); }
            set { NativeMethods.dGeomSphereSetRadius(Id, value); }
        }

        public dReal PointDepth(dReal x, dReal y, dReal z)
        {
            return NativeMethods.dGeomSpherePointDepth(Id, x, y, z);
        }
    }
}
