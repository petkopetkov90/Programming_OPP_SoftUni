using Singleton.Models;

namespace Singleton;

public class StartUp
{
    static void Main()
    {
        var demo = SingletonDataContainer.Instance;
        Console.WriteLine(demo.GetPopulation("Sofia"));
        var demo2 = SingletonDataContainer.Instance;
        Console.WriteLine(demo.GetPopulation("Plovdiv"));

    }
}
