
namespace WildFarm.Models;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

    protected override double weightIncreaseFactor => 0.30;

    public override string ProduceSound()
    {
        return "Meow";
    }
}
