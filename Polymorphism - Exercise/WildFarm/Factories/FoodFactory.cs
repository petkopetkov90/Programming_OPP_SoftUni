
using WildFarm.Exceptions;
using WildFarm.Factories.Interaces;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class FoodFactory : IFoodFactory
{
    public IFood CreateFood(string[] foodDetails)
    {
        string foodType = foodDetails[0];
        int foodQuantity = int.Parse(foodDetails[1]);

        switch (foodType)
        {
            case "Vegetable":
                return new Vegetable(foodQuantity);
            case "Fruit":
                return new Fruit(foodQuantity);
            case "Meat":
                return new Meat(foodQuantity);
            case "Seeds":
                return new Seeds(foodQuantity);
            default:
                throw new InvalidFoodType();
        }
    }
}
