using Facade.Models;

namespace Facade;

public class StartUp
{
    static void Main()
    {
        Car car = new CarBuilderFacade()
            .Info.WithType("BMW")
                 .WithColor("Black")
                 .WithNumberOfDoors(5)
            .Built.InCity("Leipzig")
                  .AtAddress("Some address")
            .Build();

        Console.WriteLine(car);
    }
}
