using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;
using SimpleSnake.Utilities;

namespace SimpleSnake;

public class StartUp
{
    public static void Main()
    {
        ConsoleWindow.CustomizeConsole();

        Wall wall = new Wall();
        Snake snake = new Snake();
        Food[] foods = new Food[]
        {
            new FoodAsterisk(0, 0),
            new FoodDollar(0, 0),
            new FoodHash(0, 0),
        };

        IEngine engine = new Engine(wall, snake, foods);
        engine.Run();
    }
}