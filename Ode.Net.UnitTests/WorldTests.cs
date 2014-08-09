using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using dReal = System.Single;
using System.Runtime.InteropServices;

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
        public void GetSetGravity_ReturnsCorrectValue()
        {
            world.Gravity = Vector3.One;
            Assert.AreEqual(Vector3.One, world.Gravity);
        }

        [TestMethod]
        public void GetSetErp_ReturnsCorrectValue()
        {
            const dReal Erp = (dReal)0.1;
            world.Erp = Erp;
            Assert.AreEqual(Erp, world.Erp);
        }

        [TestMethod]
        public void GetSetCfm_ReturnsCorrectValue()
        {
            const dReal Cfm = (dReal)0.5;
            world.Cfm = Cfm;
            Assert.AreEqual(Cfm, world.Cfm);
        }

        [TestMethod]
        public void GetSetStepIslandsProcessingMaxThreadCount_ReturnsCorrectValue()
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
            var policyInfo = new WorldStepReserveInfo();
            world.SetStepMemoryReservationPolicy(policyInfo);
            world.SetStepMemoryReservationPolicy(null);
        }

        [TestMethod]
        public void SetStepMemoryManager_Returns()
        {
            const dReal StepSize = (dReal)0.1;
            var memoryManager = new WorldStepMemoryFunctionsInfo(
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
    }
}
