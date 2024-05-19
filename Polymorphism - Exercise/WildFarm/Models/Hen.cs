
namespace WildFarm.Models;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

    protected override double weightIncreaseFactor => 0.35;

    public override string ProduceSound()
    {
        return "Cluck";
    }
}
