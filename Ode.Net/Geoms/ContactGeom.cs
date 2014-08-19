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
    public struct ContactGeom
    {
        Vector3 pos;
        Vector3 normal;
        dReal depth;
        IntPtr g1, g2;
        int side1, side2;
    }
}
