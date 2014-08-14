using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public abstract class Geom : IDisposable
    {
        readonly dGeomID id;

        internal static Geom FromIntPtr(IntPtr value)
        {
            throw new NotImplementedException();
        }

        internal dGeomID Id
        {
            get { return id; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
