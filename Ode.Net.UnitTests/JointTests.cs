using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ode.Net.Joints;
using dReal = System.Single;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class JointTests
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
        public void JointFeedback_ApplyBodyForce_ReadNonZeroFeedback()
        {
            const dReal StepSize = (dReal)0.1;

            Engine.Init();
            Engine.AllocateDataForThread(AllocateDataFlags.All);
            using (var world = new World())
            using (var body1 = new Body(world))
            using (var body2 = new Body(world))
            using (var joint = new Ball(world))
            {
                body1.Position = new Vector3(1, 0, 0);
                body2.Position = new Vector3(0, 1, 0);
                joint.Attach(body1, body2);

                var feedback = new JointFeedback();
                joint.Feedback = feedback;

                world.QuickStep(StepSize);
                Assert.AreEqual(Vector3.Zero, joint.Feedback.ForceOnBody1);
                body1.AddForce(new Vector3(0, 0, 1));
                world.QuickStep(StepSize);
                Assert.AreNotEqual(Vector3.Zero, joint.Feedback.ForceOnBody1);
            }
            Engine.Close();
        }
    }
}
