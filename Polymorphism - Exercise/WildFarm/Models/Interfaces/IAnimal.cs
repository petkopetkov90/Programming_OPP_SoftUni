
namespace WildFarm.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }

    void Eat(IFood foodType);

    string ProduceSound();
}
