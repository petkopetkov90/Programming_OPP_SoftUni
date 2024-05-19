
using WildFarm.Models.Interfaces;

namespace WildFarm.Models;

public abstract class Food : IFood
{
    public Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; private set; }
}
