using Moq;
using NUnit.Framework;
using Skeleton.Models;

namespace Skeleton.Tests;

public class HeroTests
{
    private Mock<Axe> axe;
    private Mock<Dummy> dummy;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {

        axe = new Mock<Axe>(MockBehavior.Default, 3, 3);
        dummy = new Mock<Dummy>(MockBehavior.Default, 3, 3);
        hero = new Hero("Gosho", axe.Object);
    }

    [Test]
    public void ConstructorShouldWorkCorrectly()
    {
        Assert.IsNotNull(hero);
        Assert.IsInstanceOf<Hero>(hero);
        Assert.AreEqual(hero.Experience, 0);
    }

    [Test]
    public void AttackMethotShouldAttackCorrectlyAndGiveExperienceWhenTargetIsDead()
    {
        hero.Attack(dummy.Object);
        Assert.AreEqual(3, hero.Experience);
    }

    [Test]
    public void AttackMethotShouldAttackCorrectlyAndNotGiveExperienceWhenTargenIsNotDead()
    {
        dummy = new Mock<Dummy>(MockBehavior.Default, 5, 3);
        hero.Attack(dummy.Object);
        Assert.AreEqual(0, hero.Experience);
    }

}
