using Ode.Net.Native;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net
{
    public class World : IDisposable
    {
        readonly dWorldID id;

        public World()
        {
            id = NativeMethods.dWorldCreate();
        }

        public Vector3 Gravity
        {
            get
            {
                Vector3 result;
                NativeMethods.dWorldGetGravity(id, out result);
                return result;
            }
            set
            {
                NativeMethods.dWorldSetGravity(id, value.X, value.Y, value.Z);
            }
        }

        public void Dispose()
        {
            id.Close();
        }
    }
}
