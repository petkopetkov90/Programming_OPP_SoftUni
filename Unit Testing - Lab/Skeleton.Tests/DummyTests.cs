using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(100, 10);
        }

        [Test]
        public void DummyShouldLoseHealthWhenIsAttacked()
        {
            dummy.TakeAttack(10);
            int expectedHP = 90;

            Assert.AreEqual(expectedHP, dummy.Health, $"Expected HP was {expectedHP} but result is {dummy.Health}");
        }

        [Test]
        public void DeadDummyShouldThrowExceptionWhenIsAttacked()
        {
            dummy.TakeAttack(100);

            Assert.That(() => dummy.TakeAttack(100), Throws.Exception.TypeOf(typeof(InvalidOperationException)), "Attacking dead dummy should throw an exception");
        }

        [Test]
        public void DeadDummyShouldGiveExperienceCorrectly()
        {
            dummy.TakeAttack(attackPoints: 100);
            int expectedExperience = 10;
            int actualExperience = dummy.GiveExperience();

            Assert.AreEqual(expectedExperience, actualExperience, $"Expected experience was {expectedExperience} but resutl is {actualExperience}");
        }

        [Test]
        public void AliveDummyShouldNotGiveExperienceButThrowAnExeption()
        {

            Assert.That(() => dummy.GiveExperience(), Throws.Exception.TypeOf(typeof(InvalidOperationException)), "Alive dummy must not give any experience but throws an exception");
        }
    }
}