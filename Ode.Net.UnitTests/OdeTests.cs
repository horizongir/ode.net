using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ode.Net.UnitTests
{
    static class OdeTests
    {
        internal static void Initialize()
        {
            Engine.Init();
            Engine.AllocateDataForThread(AllocateDataFlags.All);
        }

        internal static void Cleanup()
        {
            Engine.Close();
        }
    }
}
