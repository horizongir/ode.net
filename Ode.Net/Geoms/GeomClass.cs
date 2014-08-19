using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    public enum GeomClass
    {
        Sphere = 0,
        Box,
        Capsule,
        Cylinder,
        Plane,
        Ray,
        Convex,
        GeomTransform,
        TriMesh,
        Heightfield,

        FirstSpace,
        SimpleSpace = FirstSpace,
        HashSpace,
        SweepAndPruneSpace,
        QuadTreeSpace,
        LastSpace = QuadTreeSpace,

        FirstUserClass,
        LastUserClass = FirstUserClass + NativeMethods.MaxUserClasses - 1,
        GeomNumClasses
    }
}
