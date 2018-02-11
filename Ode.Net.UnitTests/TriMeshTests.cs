using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Collision;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class TriMeshTests
    {
        [TestInitialize]
        public void Initialize()
        {
            OdeTests.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            OdeTests.Cleanup();
        }

        [TestMethod]
        public void BuildSingle_CreatesValidTriMesh()
        {
            var data = new TriMeshData();
            var vertices = new float[]
            {
                -1, -1, 0,
                 1, -1, 0,
                 1,  1, 0,
                -1,  1, 0
            };

            var indices = new int[] { 0, 1, 2, 0, 2, 3 };
            data.BuildSingle(vertices, indices);
            using (var triMesh = new TriMesh(data))
            {
                Assert.AreEqual(indices.Length / 3, triMesh.TriangleCount);
            }
        }
    }
}
