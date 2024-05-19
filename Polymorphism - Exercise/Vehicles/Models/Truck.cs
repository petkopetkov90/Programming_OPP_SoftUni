
namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double AirConditionerConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity, AirConditionerConsumption)
    {
    }

    public override void Refuel(double liters)
    {
        if (liters > TankCapacity - InitialFuel)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        base.Refuel(liters * 0.95);
    }
}
