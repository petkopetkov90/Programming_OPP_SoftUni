

using Vehicles.Models.interfaces;

namespace Vehicles.Factories.Interfaces;

public interface IVehicleFactory
{
    IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
}
