using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public abstract class Geom : IDisposable
    {
        readonly dGeomID id;

        internal Geom(dGeomID geom)
        {
            id = geom;
            var handle = GCHandle.Alloc(this);
            NativeMethods.dGeomSetData(id, GCHandle.ToIntPtr(handle));
        }

        internal static Geom FromIntPtr(IntPtr value)
        {
            if (value == IntPtr.Zero) return null;
            var handlePtr = NativeMethods.dGeomGetData(value);
            if (handlePtr == IntPtr.Zero) return null;
            var handle = GCHandle.FromIntPtr(handlePtr);
            return (Geom)handle.Target;
        }

        internal dGeomID Id
        {
            get { return id; }
        }

        public void Dispose()
        {
            if (!id.IsInvalid)
            {
                var handlePtr = NativeMethods.dGeomGetData(id);
                var handle = GCHandle.FromIntPtr(handlePtr);
                handle.Free();
                id.Close();
            }
        }
    }
}
