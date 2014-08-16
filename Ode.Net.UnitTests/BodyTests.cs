using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Joints;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class BodyTests
    {
        World world;
        Body body;

        [TestInitialize]
        public void Initialize()
        {
            world = new World();
            body = new Body(world);
        }

        [TestCleanup]
        public void Cleanup()
        {
            body.Dispose();
            world.Dispose();
        }

        [TestMethod]
        public void AutoDisableLinearThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisableLinearThreshold;
            body.AutoDisableLinearThreshold = value + 1;
            Assert.AreEqual(value + 1, body.AutoDisableLinearThreshold);
            body.AutoDisableLinearThreshold = value;
        }

        [TestMethod]
        public void AutoDisableAngularThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisableAngularThreshold;
            body.AutoDisableAngularThreshold = value + 1;
            Assert.AreEqual(value + 1, body.AutoDisableAngularThreshold);
            body.AutoDisableAngularThreshold = value;
        }

        [TestMethod]
        public void AutoDisableAverageSamplesCount_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisableAverageSamplesCount;
            body.AutoDisableAverageSamplesCount = value + 1;
            Assert.AreEqual(value + 1, body.AutoDisableAverageSamplesCount);
            body.AutoDisableAverageSamplesCount = value;
        }

        [TestMethod]
        public void AutoDisableSteps_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisableSteps;
            body.AutoDisableSteps = value + 1;
            Assert.AreEqual(value + 1, body.AutoDisableSteps);
            body.AutoDisableSteps = value;
        }

        [TestMethod]
        public void AutoDisableTime_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisableTime;
            body.AutoDisableTime = value + 1;
            Assert.AreEqual(value + 1, body.AutoDisableTime);
            body.AutoDisableTime = value;
        }

        [TestMethod]
        public void AutoDisable_GetSet_ReturnsCorrectValue()
        {
            var value = body.AutoDisable;
            body.AutoDisable = !value;
            Assert.AreEqual(!value, body.AutoDisable);
            body.AutoDisable = value;
        }

        [TestMethod]
        public void LinearDampingThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = body.LinearDampingThreshold;
            body.LinearDampingThreshold = value + 1;
            Assert.AreEqual(value + 1, body.LinearDampingThreshold);
            body.LinearDampingThreshold = value;
        }

        [TestMethod]
        public void AngularDampingThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = body.AngularDampingThreshold;
            body.AngularDampingThreshold = value + 1;
            Assert.AreEqual(value + 1, body.AngularDampingThreshold);
            body.AngularDampingThreshold = value;
        }

        [TestMethod]
        public void LinearDamping_GetSet_ReturnsCorrectValue()
        {
            var value = body.LinearDamping;
            body.LinearDamping = value + 1;
            Assert.AreEqual(value + 1, body.LinearDamping);
            body.LinearDamping = value;
        }

        [TestMethod]
        public void AngularDamping_GetSet_ReturnsCorrectValue()
        {
            var value = body.AngularDamping;
            body.AngularDamping = value + 1;
            Assert.AreEqual(value + 1, body.AngularDamping);
            body.AngularDamping = value;
        }

        [TestMethod]
        public void MaxAngularSpeed_GetSet_ReturnsCorrectValue()
        {
            var value = body.MaxAngularSpeed;
            body.MaxAngularSpeed = value + 1;
            Assert.AreEqual(value + 1, body.MaxAngularSpeed);
            body.MaxAngularSpeed = value;
        }

        [TestMethod]
        public void SetDamping_CorrectlyUpdateState()
        {
            var linear = body.LinearDamping;
            var angular = body.AngularDamping;
            body.SetDamping(linear + 1, angular + 1);
            Assert.AreEqual(linear + 1, body.LinearDamping);
            Assert.AreEqual(angular + 1, body.AngularDamping);
            body.LinearDamping = linear;
            body.AngularDamping = angular;
        }

        [TestMethod]
        public void GetConnectingJoint_NonConnectedBodies_ReturnsNull()
        {
            using (var body1 = new Body(world))
            using (var body2 = new Body(world))
            {
                Assert.IsNull(body1.GetConnectingJoint(body2));
            }
        }

        [TestMethod]
        public void GetConnectingJoint_ConnectedBodies_ReturnsJoint()
        {
            using (var body1 = new Body(world))
            using (var body2 = new Body(world))
            using (var ballJoint = new Ball(world))
            {
                ballJoint.Attach(body1, body2);
                Assert.AreSame(ballJoint, body1.GetConnectingJoint(body2));
            }
        }
    }
}
