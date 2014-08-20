using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net.Geoms
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        public dReal MinX;
        public dReal MaxX;
        public dReal MinY;
        public dReal MaxY;
        public dReal MinZ;
        public dReal MaxZ;
    }
}
