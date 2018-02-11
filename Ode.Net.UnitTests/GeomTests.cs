using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Collision;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class GeomTests
    {
        Space space;
        Geom geom;

        [TestInitialize]
        public void Initialize()
        {
            OdeTests.Initialize();
            space = new SimpleSpace();
            geom = new Sphere(1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            geom.Dispose();
            space.Dispose();
            OdeTests.Cleanup();
        }

        [TestMethod]
        public void InverseCleanup()
        {
            space.Dispose();
            geom.Dispose();
        }

        [TestMethod]
        public void CategoryBits_GetSet_ReturnsCorrectValue()
        {
            geom.CategoryBits = -1;
            Assert.AreEqual(-1, geom.CategoryBits);
        }
    }
}
