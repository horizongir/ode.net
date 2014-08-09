using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

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
        public void GetSetGravity_ReturnsCorrectValue()
        {
            world.Gravity = Vector3.One;
            Assert.AreEqual(world.Gravity, Vector3.One);
        }
    }
}
