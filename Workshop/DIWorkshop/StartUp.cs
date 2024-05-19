using DIWorkshop.DI;
using DIWorkshop.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DIWorkshop;

public class StartUp
{
    static void Main()
    {
        IServiceProvider serviceProvider = DIContainer.BuildServiceProvider();

        IEngine engine = serviceProvider.GetService<IEngine>();
        IEngine engine2 = serviceProvider.GetService<IEngine>();
        IEngine engine3 = serviceProvider.GetService<IEngine>();
        IEngine engine4 = serviceProvider.GetService<IEngine>();

        engine.Run();
    }
}
