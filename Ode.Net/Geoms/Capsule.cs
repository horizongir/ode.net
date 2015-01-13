using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Capsule : Geom
    {
        public Capsule(dReal radius, dReal length)
            : this(null, radius, length)
        {
        }

        public Capsule(Space space, dReal radius, dReal length)
            : base(NativeMethods.dCreateCapsule(space != null ? space.Id : dSpaceID.Null, radius, length))
        {
        }

        public dReal Radius
        {
            get
            {
                dReal radius, length;
                NativeMethods.dGeomCapsuleGetParams(Id, out radius, out length);
                return radius;
            }
            set
            {
                dReal radius, length;
                NativeMethods.dGeomCapsuleGetParams(Id, out radius, out length);
                NativeMethods.dGeomCapsuleSetParams(Id, value, length);
            }
        }

        public dReal Length
        {
            get
            {
                dReal radius, length;
                NativeMethods.dGeomCapsuleGetParams(Id, out radius, out length);
                return length;
            }
            set
            {
                dReal radius, length;
                NativeMethods.dGeomCapsuleGetParams(Id, out radius, out length);
                NativeMethods.dGeomCapsuleSetParams(Id, radius, value);
            }
        }

        public dReal PointDepth(dReal x, dReal y, dReal z)
        {
            return NativeMethods.dGeomCapsulePointDepth(Id, x, y, z);
        }
    }
}
