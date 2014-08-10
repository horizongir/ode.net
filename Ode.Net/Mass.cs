using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Mass
    {
        public dReal mass;
        public Vector3 c;
        public Matrix3 I;
    }
}
