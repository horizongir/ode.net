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
    public struct SurfaceParameters
    {
        ContactModes mode;
        dReal mu;
        dReal mu2;
        dReal rho;
        dReal rho2;
        dReal rhoN;
        dReal bounce;
        dReal bounce_vel;
        dReal soft_erp;
        dReal soft_cfm;
        dReal motion1, motion2, motionN;
        dReal slip1, slip2;
    }
}
