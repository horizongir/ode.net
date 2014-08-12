using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dReal = System.Single;

namespace Ode.Net.UnitTests
{
    [TestClass]
    public class MassTests
    {
        const dReal DefaultMass = 1;
        const dReal DefaultParameter = 1;

        [TestMethod]
        public void IsValid_SphereMass_ReturnsTrue()
        {
            var mass = Mass.CreateSphereTotal(DefaultMass, DefaultParameter);
            Assert.IsTrue(mass.IsValid);
        }

        [TestMethod]
        public void IsValid_ZeroMass_ReturnsFalse()
        {
            var mass = new Mass();
            Assert.IsFalse(mass.IsValid);
        }

        [TestMethod]
        public void Adjust_UnitSphereMass_UpdatesTotalMass()
        {
            const dReal NewMass = 2;
            var mass = Mass.CreateSphereTotal(DefaultMass, DefaultParameter);
            Assert.AreEqual(DefaultMass, mass.TotalMass);
            mass = Mass.Adjust(mass, NewMass);
            Mass.Adjust(ref mass, NewMass * 2, out mass);
            Assert.AreEqual(NewMass * 2, mass.TotalMass);
        }
    }
}
