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
    public struct Vector4
    {
        public dReal X;
        public dReal Y;
        public dReal Z;
        public dReal W;
    }
}
