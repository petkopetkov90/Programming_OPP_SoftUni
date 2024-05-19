using Animals.Models.Interfaces;

namespace Animals.Models;

public abstract class Animal : IAnimal
{
    protected Animal(string name, string favoriteFood)
    {
        Name = name;
        FavoriteFood = favoriteFood;
    }

    public string Name { get; private set; }

    public string FavoriteFood { get; private set; }

    public virtual string ExplainSelf()
    {
        return $"I am {Name} and my fovourite food is {FavoriteFood}";

    }

}
