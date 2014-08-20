using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    public class Sphere : Geom
    {
        public Sphere(dReal radius)
            : base(NativeMethods.dCreateSphere(dSpaceID.Null, radius))
        {
        }
    }
}
