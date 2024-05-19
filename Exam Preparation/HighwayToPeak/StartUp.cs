using HighwayToPeak.Core;
using HighwayToPeak.Core.Contracts;

namespace HighwayToPeak;
public class StartUp
{
    static void Main(string[] args)
    {
        IEngine engine = new Engine();
        engine.Run();
    }
}