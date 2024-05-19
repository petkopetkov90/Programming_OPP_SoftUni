namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private List<Warrior> warriors;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            warriors = new List<Warrior>();
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsInstanceOf<Arena>(arena);
            Assert.AreEqual(warriors.Count, arena.Count);
        }

        [Test]
        public void ArenaEnrollMethodShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("warr1", 10, 100);
            warriors.Add(warrior);
            arena.Enroll(warrior);
            Assert.AreEqual(warriors, arena.Warriors);
            Assert.AreEqual(warriors.Count, arena.Count);
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowAnExceptionIfWarriorsWasEnrolledAlready()
        {
            Warrior warrior = new Warrior("warr1", 10, 100);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightMethodShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("warr1", 10, 100);
            Warrior warrior2 = new Warrior("warr2", 20, 200);
            warriors.Add(warrior);
            warriors.Add(warrior2);
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            int warriorExpectedHp = 100 - 20;
            int warrior2ExpectedHp = 200 - 10;

            arena.Fight("warr1", "warr2");

            Assert.AreEqual(warriors, arena.Warriors);
            Assert.AreEqual(warriorExpectedHp, warrior.HP);
            Assert.AreEqual(warrior2ExpectedHp, warrior2.HP);
        }

        [TestCase("warr1", "wrongName")]
        [TestCase("wrongName", "warr1")]
        public void ArenaFightMethodShouldThrowAnExceptionWhenAttackerIsNotEnrolled(string attacker, string defender)
        {
            Warrior warrior = new Warrior("warr1", 10, 100);

            arena.Enroll(warrior);

            string missingName = "wrongName";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));

            Assert.AreEqual($"There is no fighter with name {missingName} enrolled for the fights!", exception.Message);
        }
    }
}
