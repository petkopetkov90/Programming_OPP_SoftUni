


namespace WildFarm.Models;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Meat) };

    protected override double weightIncreaseFactor => 0.25;

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}
