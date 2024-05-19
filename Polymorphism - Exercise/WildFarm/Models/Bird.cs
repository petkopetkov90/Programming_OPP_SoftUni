
namespace WildFarm.Models;

public abstract class Bird : Animal
{
    protected Bird(string name, double weight, double wingSize) : 
        base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize { get; private set; }

    public override string ToString()
    {
        return base.ToString() + $" {WingSize}, {Weight}, {FoodEaten}]";
    }
}
