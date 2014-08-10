using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class BodyTests
    {
        World world;
        Body body;

        [TestInitialize]
        public void InitializeBody()
        {
            world = new World();
            body = new Body(world);
        }

        [TestCleanup]
        public void CleanupBody()
        {
            body.Dispose();
            world.Dispose();
        }
    }
}
