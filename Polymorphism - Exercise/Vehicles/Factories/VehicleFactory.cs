
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.interfaces;

namespace Vehicles.Factories;

public class VehicleFactory : IVehicleFactory
{

    public IVehicle Create(string type, double initialFuel, double fuelConsumption, double tankCapacity)
    {

        switch (type)
        {
            case "Car":
                return new Car(initialFuel, fuelConsumption, tankCapacity);
            case "Truck":
                return new Truck(initialFuel, fuelConsumption, tankCapacity);
            case "Bus":
                return new Bus(initialFuel, fuelConsumption, tankCapacity);
            default:
                throw new ArgumentException("Invalid vehicle type!");
        }
    }
}
