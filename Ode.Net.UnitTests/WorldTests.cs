using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;
using dReal = System.Single;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class WorldTests
    {
        World world;

        [TestInitialize]
        public void InitializeWorld()
        {
            Ode.Init();
            Ode.AllocateDataForThread(AllocateDataFlags.All);
            world = new World();
        }

        [TestCleanup]
        public void CleanupWorld()
        {
            world.Dispose();
            Ode.Close();
        }

        [TestMethod]
        public void Gravity_GetSet_ReturnsCorrectValue()
        {
            world.Gravity = Vector3.One;
            Assert.AreEqual(Vector3.One, world.Gravity);
        }

        [TestMethod]
        public void Erp_GetSet_ReturnsCorrectValue()
        {
            const dReal Erp = (dReal)0.1;
            world.Erp = Erp;
            Assert.AreEqual(Erp, world.Erp);
        }

        [TestMethod]
        public void Cfm_GetSet_ReturnsCorrectValue()
        {
            const dReal Cfm = (dReal)0.5;
            world.Cfm = Cfm;
            Assert.AreEqual(Cfm, world.Cfm);
        }

        [TestMethod]
        public void StepIslandsProcessingMaxThreadCount_GetSet_ReturnsCorrectValue()
        {
            const int MaxThreads = 2;
            world.StepIslandsProcessingMaxThreadCount = MaxThreads;
            Assert.AreEqual(MaxThreads, world.StepIslandsProcessingMaxThreadCount);
            world.StepIslandsProcessingMaxThreadCount = World.StepThreadCountUnlimited;
            Assert.AreEqual(World.StepThreadCountUnlimited, world.StepIslandsProcessingMaxThreadCount);
        }

        [TestMethod]
        public void UseSharedWorkingMemory_Returns()
        {
            using (var fromWorld = new World())
            {
                world.UseSharedWorkingMemory(fromWorld);
                world.UseSharedWorkingMemory(null);
            }
        }

        [TestMethod]
        public void CleanupWorkingMemory_Returns()
        {
            world.CleanupWorkingMemory();
        }

        [TestMethod]
        public void SetStepMemoryReservationPolicy_Returns()
        {
            var policyInfo = new WorldStepMemoryReservationPolicy();
            world.SetStepMemoryReservationPolicy(policyInfo);
            world.SetStepMemoryReservationPolicy(null);
        }

        [TestMethod]
        public void SetStepMemoryManager_Returns()
        {
            const dReal StepSize = (dReal)0.1;
            var memoryManager = new WorldStepMemoryManager(
                (size) => Marshal.AllocHGlobal(size),
                (ptr, ss, sf) => Marshal.ReAllocHGlobal(ptr, sf),
                (ptr, ss) => Marshal.FreeHGlobal(ptr));
            world.SetStepMemoryManager(memoryManager);
            world.Step(StepSize);
            world.CleanupWorkingMemory();
            world.SetStepMemoryManager(null);
        }

        [TestMethod]
        public void Step_Returns()
        {
            const dReal StepSize = (dReal)0.1;
            world.Step(StepSize);
        }

        [TestMethod]
        public void QuickStep_Returns()
        {
            const dReal StepSize = (dReal)0.1;
            world.QuickStep(StepSize);
        }

        [TestMethod]
        public void ImpulseToForce_ReturnsCorrectForceVector()
        {
            const dReal StepSize = (dReal)0.1;
            const dReal ForceComponents = 1 / StepSize;
            var impulse = Vector3.One;
            var force = world.ImpulseToForce(StepSize, impulse);
            Assert.AreEqual(ForceComponents, force.X);
            Assert.AreEqual(ForceComponents, force.Y);
            Assert.AreEqual(ForceComponents, force.Z);
            world.ImpulseToForce(StepSize, ref impulse, out force);
            Assert.AreEqual(ForceComponents, force.X);
            Assert.AreEqual(ForceComponents, force.Y);
            Assert.AreEqual(ForceComponents, force.Z);
        }

        [TestMethod]
        public void QuickStepNumIterations_GetSet_ReturnsCorrectValue()
        {
            var value = world.QuickStepNumIterations;
            world.QuickStepNumIterations = value + 1;
            Assert.AreEqual(value + 1, world.QuickStepNumIterations);
            world.QuickStepNumIterations = value;
        }

        [TestMethod]
        public void QuickStepW_GetSet_ReturnsCorrectValue()
        {
            var value = world.QuickStepW;
            world.QuickStepW = value + 1;
            Assert.AreEqual(value + 1, world.QuickStepW);
            world.QuickStepW = value;
        }

        [TestMethod]
        public void ContactMaxCorrectingVelocity_GetSet_ReturnsCorrectValue()
        {
            var value = world.ContactMaxCorrectingVelocity;
            world.ContactMaxCorrectingVelocity = value + 1;
            Assert.AreEqual(value + 1, world.ContactMaxCorrectingVelocity);
            world.ContactMaxCorrectingVelocity = value;
        }

        [TestMethod]
        public void ContactSurfaceLayer_GetSet_ReturnsCorrectValue()
        {
            var value = world.ContactSurfaceLayer;
            world.ContactSurfaceLayer = value + 1;
            Assert.AreEqual(value + 1, world.ContactSurfaceLayer);
            world.ContactSurfaceLayer = value;
        }

        [TestMethod]
        public void AutoDisableLinearThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisableLinearThreshold;
            world.AutoDisableLinearThreshold = value + 1;
            Assert.AreEqual(value + 1, world.AutoDisableLinearThreshold);
            world.AutoDisableLinearThreshold = value;
        }

        [TestMethod]
        public void AutoDisableAngularThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisableAngularThreshold;
            world.AutoDisableAngularThreshold = value + 1;
            Assert.AreEqual(value + 1, world.AutoDisableAngularThreshold);
            world.AutoDisableAngularThreshold = value;
        }

        [TestMethod]
        public void AutoDisableAverageSamplesCount_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisableAverageSamplesCount;
            world.AutoDisableAverageSamplesCount = value + 1;
            Assert.AreEqual(value + 1, world.AutoDisableAverageSamplesCount);
            world.AutoDisableAverageSamplesCount = value;
        }

        [TestMethod]
        public void AutoDisableSteps_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisableSteps;
            world.AutoDisableSteps = value + 1;
            Assert.AreEqual(value + 1, world.AutoDisableSteps);
            world.AutoDisableSteps = value;
        }

        [TestMethod]
        public void AutoDisableTime_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisableTime;
            world.AutoDisableTime = value + 1;
            Assert.AreEqual(value + 1, world.AutoDisableTime);
            world.AutoDisableTime = value;
        }

        [TestMethod]
        public void AutoDisable_GetSet_ReturnsCorrectValue()
        {
            var value = world.AutoDisable;
            world.AutoDisable = !value;
            Assert.AreEqual(!value, world.AutoDisable);
            world.AutoDisable = value;
        }

        [TestMethod]
        public void LinearDampingThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = world.LinearDampingThreshold;
            world.LinearDampingThreshold = value + 1;
            Assert.AreEqual(value + 1, world.LinearDampingThreshold);
            world.LinearDampingThreshold = value;
        }

        [TestMethod]
        public void AngularDampingThreshold_GetSet_ReturnsCorrectValue()
        {
            var value = world.AngularDampingThreshold;
            world.AngularDampingThreshold = value + 1;
            Assert.AreEqual(value + 1, world.AngularDampingThreshold);
            world.AngularDampingThreshold = value;
        }

        [TestMethod]
        public void LinearDamping_GetSet_ReturnsCorrectValue()
        {
            var value = world.LinearDamping;
            world.LinearDamping = value + 1;
            Assert.AreEqual(value + 1, world.LinearDamping);
            world.LinearDamping = value;
        }

        [TestMethod]
        public void AngularDamping_GetSet_ReturnsCorrectValue()
        {
            var value = world.AngularDamping;
            world.AngularDamping = value + 1;
            Assert.AreEqual(value + 1, world.AngularDamping);
            world.AngularDamping = value;
        }

        [TestMethod]
        public void MaxAngularSpeed_GetSet_ReturnsCorrectValue()
        {
            var value = world.MaxAngularSpeed;
            world.MaxAngularSpeed = value + 1;
            Assert.AreEqual(value + 1, world.MaxAngularSpeed);
            world.MaxAngularSpeed = value;
        }

        [TestMethod]
        public void SetDamping_CorrectlyUpdateState()
        {
            var linear = world.LinearDamping;
            var angular = world.AngularDamping;
            world.SetDamping(linear + 1, angular + 1);
            Assert.AreEqual(linear + 1, world.LinearDamping);
            Assert.AreEqual(angular + 1, world.AngularDamping);
            world.LinearDamping = linear;
            world.AngularDamping = angular;
        }
    }
}
