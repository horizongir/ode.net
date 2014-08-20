using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public abstract class Space : Geom, IEnumerable<Geom>
    {
        readonly dSpaceID id;

        internal Space(dSpaceID space)
            : base(space)
        {
            id = space;
        }

        internal new dSpaceID Id
        {
            get { return id; }
        }

        internal new static Space FromIntPtr(IntPtr value)
        {
            return (Space)Geom.FromIntPtr(value);
        }

        public bool Cleanup
        {
            get { return NativeMethods.dSpaceGetCleanup(id) != 0; }
            set { NativeMethods.dSpaceSetCleanup(id, value ? 1 : 0); }
        }

        public int Sublevel
        {
            get { return NativeMethods.dSpaceGetSublevel(id); }
            set { NativeMethods.dSpaceSetSublevel(id, value); }
        }

        public bool ManualCleanup
        {
            get { return NativeMethods.dSpaceGetManualCleanup(id) != 0; }
            set { NativeMethods.dSpaceSetManualCleanup(id, value ? 1 : 0); }
        }

        public void Add(Geom geom)
        {
            if (geom == null)
            {
                throw new ArgumentNullException("geom");
            }

            NativeMethods.dSpaceAdd(id, geom.Id);
        }

        public void Remove(Geom geom)
        {
            if (geom == null)
            {
                throw new ArgumentNullException("geom");
            }

            NativeMethods.dSpaceRemove(id, geom.Id);
        }

        public bool Contains(Geom geom)
        {
            return NativeMethods.dSpaceQuery(id, geom.Id) != 0;
        }

        public void Clear()
        {
            NativeMethods.dSpaceClean(id);
        }

        private void NearCallback(IntPtr data, IntPtr o1, IntPtr o2)
        {

        }

        public void Collide()
        {
            NativeMethods.dSpaceCollide(id, IntPtr.Zero, NearCallback);
        }

        public void Collide(Geom geom)
        {
            NativeMethods.dSpaceCollide2(id, geom.Id, IntPtr.Zero, NearCallback);
        }

        public IEnumerator<Geom> GetEnumerator()
        {
            var numGeoms = NativeMethods.dSpaceGetNumGeoms(id);
            for (int i = 0; i < numGeoms; i++)
            {
                yield return Geom.FromIntPtr(NativeMethods.dSpaceGetGeom(id, i));
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
