
namespace WildFarm.Models;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override IReadOnlyCollection<Type> foodTypes => new HashSet<Type>() { typeof(Meat) };

    protected override double weightIncreaseFactor => 1.00;

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }
}
