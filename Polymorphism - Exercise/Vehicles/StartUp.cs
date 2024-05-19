using Vehicles.Core;
using Vehicles.Core.interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

namespace Vehicles;

public class StartUp
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IVehicleFactory vehicleFactory = new VehicleFactory();

        IEngine engine = new Engine(reader, writer, vehicleFactory);
        
        engine.Start();
    }
}
