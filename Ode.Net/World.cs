using Ode.Net.Native;
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

        public void Dispose()
        {
            id.Close();
        }
    }
}
