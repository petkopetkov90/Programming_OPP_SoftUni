using DIWorkshop.Models.Interfaces;

namespace DIWorkshop.Models;

public class Engine : IEngine
{
    public Engine()
    {
        Console.WriteLine("Initializing new Engine");
    }
    public void Run()
    {
        Console.WriteLine("Running Engine");
    }
}
