using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace WildFarm;

public class StartUp
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IAnimalFactory animalFactory = new AnimalFactory();
        IFoodFactory foodFactory = new FoodFactory();

        IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);
        engine.Start();
    }
}
