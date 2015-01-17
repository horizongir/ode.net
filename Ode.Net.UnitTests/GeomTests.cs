using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Collision;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class GeomTests
    {
        [TestMethod]
        public void CategoryBits_GetSet_ReturnsCorrectValue()
        {
            using (var geom = new Sphere(1))
            {
                geom.CategoryBits = -1;
                Assert.AreEqual(-1, geom.CategoryBits);
            }
        }
    }
}
