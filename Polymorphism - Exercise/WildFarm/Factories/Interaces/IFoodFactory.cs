
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] foodDetails);
    }
}
