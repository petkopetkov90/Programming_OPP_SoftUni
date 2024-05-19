using DIWorkshop.Models;
using DIWorkshop.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DIWorkshop.DI;

public class DIContainer
{
    public static IServiceProvider BuildServiceProvider()
    {
        ServiceCollection collection = new ServiceCollection();
        collection.AddSingleton<IEngine, Engine>();

        return collection.BuildServiceProvider();
    }
}
