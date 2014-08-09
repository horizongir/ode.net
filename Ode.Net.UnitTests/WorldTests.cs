using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class WorldTests
    {
        World world;

        [TestInitialize]
        public void InitializeWorld()
        {
            world = new World();
        }

        [TestCleanup]
        public void CleanupWorld()
        {
            world.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
