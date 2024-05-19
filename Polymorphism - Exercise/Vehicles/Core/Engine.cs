

using DocumentFormat.OpenXml.Drawing.Charts;
using Vehicles.Core.interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory vehicleFactory;
    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;
        vehicles = new List<IVehicle>();
    }

    public void Start()
    {

        for (int i = 0; i < 3; i++)
        {
            string[] vehicleDetails = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = vehicleDetails[0];
            double intialFuel = double.Parse(vehicleDetails[1]);
            double fuelConsumption = double.Parse(vehicleDetails[2]);
            double tankCapacity = double.Parse(vehicleDetails[3]);

            vehicles.Add(vehicleFactory.Create(type, intialFuel, fuelConsumption, tankCapacity));
        }

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                string[] commandDetails = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandDetails[0];
                string vehicleType = commandDetails[1];
                double littersOrKilometers = double.Parse(commandDetails[2]);
                IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                if (vehicle == null)
                {
                    throw new ArgumentException("Invalid vehicle type!");
                }

                switch (commandType)
                {
                    case "Drive":
                        writer.WriteLine(vehicle.Drive(littersOrKilometers));
                        break;
                    case "DriveEmpty":
                        writer.WriteLine(vehicle.DriveEmpty(littersOrKilometers));
                        break;
                    case "Refuel":
                        vehicle.Refuel(littersOrKilometers);
                        break;
                    default:
                        writer.WriteLine("Invalid command!");
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle);
        }
    }
}
