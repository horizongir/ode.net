using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Native
{
#if SINGLE_PRECISION
    using dReal = System.Single;
#elif DOUBLE_PRECISION
    using dReal = System.Double;
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif

    static partial class NativeMethods
    {
#if SINGLE_PRECISION
        const string libName = "ode_single";
#elif DOUBLE_PRECISION
        const string libName = "ode_double";
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif
    }
}
