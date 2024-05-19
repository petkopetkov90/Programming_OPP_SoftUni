namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinimumAttackHp = 30;
        private Warrior warrior;
        private string warriorName;
        private int warriorDamage;
        private int warriorHP;

        [SetUp]
        public void SetUp()
        {
            warriorName = "Assasin";
            warriorDamage = 40;
            warriorHP = 100;
            warrior = new Warrior(warriorName, warriorDamage, warriorHP);
        }

        [Test]
        public void WarriorConstructorShouldWorkCorrectly()
        {
            Assert.IsInstanceOf<Warrior>(warrior);
            Assert.IsNotNull(warrior);
            Assert.AreEqual(warriorName, warrior.Name);
            Assert.AreEqual(warriorDamage, warrior.Damage);
            Assert.AreEqual(warriorHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(" ")]
        [TestCase("\n")]
        public void WarriorConstructorShouldThrowAnExceptionWhenNameIsNullOrWhitespace(string warriorName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new Warrior(warriorName, warriorDamage, warriorHP));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void WarriorConstructorShouldThrowAnExceptionWhenDamageIsNotPositive(int warriorDamage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new Warrior(warriorName, warriorDamage, warriorHP));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-5)]
        public void WarriorConstructorShouldThrowAnExceptionWhenHpAreNegative(int warriorHP)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new Warrior(warriorName, warriorDamage, warriorHP));

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [TestCase("Target", 10, 100)]
        [TestCase("Target", 10, 35)]
        public void WarriorAttackMethodShouldWorkCorrectly(string name, int damage, int hp)
        {
            Warrior warrior2 = new Warrior(name, damage, hp);
            int expectedHP = warrior.HP - warrior2.Damage;
            int targetExpectedHp = warrior2.HP - warrior.Damage;

            if (targetExpectedHp < 0)
            {
                targetExpectedHp = 0;
            }

            warrior.Attack(warrior2);

            Assert.AreEqual(expectedHP, warrior.HP);
            Assert.AreEqual(targetExpectedHp, warrior2.HP);
        }

        [TestCase("Target", 10, 100)]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenHpIsLessThan30(string name, int damage, int hp)
        {
            Warrior warrior2 = new Warrior(name, damage, hp);
            warrior = new Warrior(warriorName, warriorDamage, MinimumAttackHp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase("Target", 10, 25)]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenTargetHpIsLessThan30(string name, int damage, int hp)
        {
            Warrior warrior2 = new Warrior(name, damage, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));

            Assert.AreEqual($"Enemy HP must be greater than {MinimumAttackHp} in order to attack him!", exception.Message);
        }

        [TestCase("Target", 110, 100)]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenTargetIsStrongerThanHP(string name, int damage, int hp)
        {
            Warrior warrior2 = new Warrior(name, damage, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));

            Assert.AreEqual($"You are trying to attack too strong enemy", exception.Message);
        }
    }
}