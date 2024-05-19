
using System.Linq;
using WildFarm.Exceptions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models;

public abstract class Animal : IAnimal
{

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public int FoodEaten { get; private set; }

    protected abstract IReadOnlyCollection<Type> foodTypes { get; }

    protected abstract double weightIncreaseFactor { get; }

    public void Eat(IFood foodType)
    {
        if (!foodTypes.Any(f => f.Name == foodType.GetType().Name))
        {
            throw new NotEatableFoodException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
        }

        FoodEaten += foodType.Quantity;
        Weight += foodType.Quantity * weightIncreaseFactor;
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name},";
    }
}
