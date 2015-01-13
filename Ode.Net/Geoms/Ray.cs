using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public sealed class Ray : Geom
    {
        public Ray(dReal length)
            : this(null, length)
        {
        }

        public Ray(Space space, dReal length)
            : base(NativeMethods.dCreateRay(space != null ? space.Id : dSpaceID.Null, length))
        {
        }

        public dReal Length
        {
            get { return NativeMethods.dGeomRayGetLength(Id); }
            set { NativeMethods.dGeomRaySetLength(Id, value); }
        }

        public Vector3 Direction
        {
            get
            {
                Vector3 start, direction;
                NativeMethods.dGeomRayGet(Id, out start, out direction);
                return direction;
            }
            set
            {
                Vector3 start;
                NativeMethods.dGeomCopyPosition(Id, out start);
                NativeMethods.dGeomRaySet(Id, start.X, start.Y, start.Z, value.X, value.Y, value.Z);
            }
        }

        public bool FirstContact
        {
            get
            {
                int first, backface;
                NativeMethods.dGeomRayGetParams(Id, out first, out backface);
                return first != 0;
            }
            set
            {
                int first, backface;
                NativeMethods.dGeomRayGetParams(Id, out first, out backface);
                NativeMethods.dGeomRaySetParams(Id, value ? 1 : 0, backface);
            }
        }

        public bool BackfaceCull
        {
            get
            {
                int first, backface;
                NativeMethods.dGeomRayGetParams(Id, out first, out backface);
                return backface != 0;
            }
            set
            {
                int first, backface;
                NativeMethods.dGeomRayGetParams(Id, out first, out backface);
                NativeMethods.dGeomRaySetParams(Id, first, value ? 1 : 0);
            }
        }

        public bool ClosestHit
        {
            get { return NativeMethods.dGeomRayGetClosestHit(Id) != 0; }
            set { NativeMethods.dGeomRaySetClosestHit(Id, value ? 1 : 0); }
        }
    }
}
