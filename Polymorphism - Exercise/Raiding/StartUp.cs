using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding;

public class StartUp
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IHeroFactory heroFactory = new HeroFactory();

        IEngine engine = new Engine(reader, writer, heroFactory);
        engine.Start();
    }
}

