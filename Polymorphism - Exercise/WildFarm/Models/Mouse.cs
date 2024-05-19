

namespace WildFarm.Models;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

    protected override double weightIncreaseFactor => 0.10;

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override string ToString()
    {
        return base.ToString() + $" {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
