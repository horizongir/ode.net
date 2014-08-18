using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Joints;
using dReal = System.Single;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class LinearMotorTests
    {
        World world;
        LinearMotor motor;

        [TestInitialize]
        public void Initialize()
        {
            OdeTests.Initialize();
            world = new World();
            motor = new LinearMotor(world);
        }

        [TestCleanup]
        public void Cleanup()
        {
            motor.Dispose();
            world.Dispose();
            OdeTests.Cleanup();
        }

        [TestMethod]
        public void Axis_GetSet_ReturnsCorrectValue()
        {
            var sqrt2over2 = (dReal)(Math.Sqrt(2) / 2);
            var targetAxis = new Vector3(0, 1, 0);
            var quaternion = new Quaternion(sqrt2over2, 0, sqrt2over2, 0);
            using (var body1 = new Body(world))
            {
                body1.Quaternion = quaternion;
                motor.Attach(body1, null);
                motor.NumAxes = 1;
                motor.Axis1 = targetAxis;
                Assert.AreEqual(targetAxis, motor.Axis1);

                motor.SetAxis(0, RelativeOrientation.FirstBody, targetAxis);
                Assert.AreEqual(targetAxis, motor.Axis1);
            }
        }
    }
}
