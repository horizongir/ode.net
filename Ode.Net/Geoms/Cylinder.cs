using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Cylinder : Geom
    {
        public Cylinder(dReal radius, dReal length)
            : this(null, radius, length)
        {
        }

        public Cylinder(Space space, dReal radius, dReal length)
            : base(NativeMethods.dCreateCylinder(space != null ? space.Id : dSpaceID.Null, radius, length))
        {
        }

        public dReal Radius
        {
            get
            {
                dReal radius, length;
                NativeMethods.dGeomCylinderGetParams(Id, out radius, out length);
                return radius;
            }
            set
            {
                dReal radius, length;
                NativeMethods.dGeomCylinderGetParams(Id, out radius, out length);
                NativeMethods.dGeomCylinderSetParams(Id, value, length);
            }
        }

        public dReal Length
        {
            get
            {
                dReal radius, length;
                NativeMethods.dGeomCylinderGetParams(Id, out radius, out length);
                return length;
            }
            set
            {
                dReal radius, length;
                NativeMethods.dGeomCylinderGetParams(Id, out radius, out length);
                NativeMethods.dGeomCylinderSetParams(Id, radius, value);
            }
        }
    }
}
