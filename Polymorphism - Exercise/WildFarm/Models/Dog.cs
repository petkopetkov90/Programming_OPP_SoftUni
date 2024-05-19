
namespace WildFarm.Models;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Meat) };

    protected override double weightIncreaseFactor => 0.40;

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override string ToString()
    {
        return base.ToString() + $" {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
