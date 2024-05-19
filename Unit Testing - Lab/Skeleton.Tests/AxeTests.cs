using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void StartUp()
        {
            axe = new Axe(10, 2);
            dummy = new Dummy(50, 2);
        }

        [Test]
        public void WeaponShouldLossDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);
            int expecterDurability = 1;
            Assert.AreEqual(expecterDurability, axe.DurabilityPoints, $"Expected durabilty was {expecterDurability} but result is {axe.DurabilityPoints}");
        }

        [Test]
        public void AttackWithBrokenWeaponShouldThrowException()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.Exception.TypeOf<InvalidOperationException>(), "Attack with broken weapon should throw an exeption");
        }
    }
}