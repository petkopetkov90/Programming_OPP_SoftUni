using FoodShortage.Engines;

namespace FoodShortage;

public class StartUp
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();
        engine.Start();
    }
}
