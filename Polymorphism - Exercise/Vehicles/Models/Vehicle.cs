
using Vehicles.Models.interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double airConditionerConsumption = 0;
    private double initialFuel;

    protected Vehicle(double initialFuel, double fuelConsumption, double tankCapacity, double airConditionerConsumption)
    {

        TankCapacity = tankCapacity;
        InitialFuel = initialFuel;
        FuelConsumption = fuelConsumption;
        this.airConditionerConsumption = airConditionerConsumption;
    }


    public double InitialFuel
    {
        get { return initialFuel; }

        private set
        {
            if (value > TankCapacity)
            {
                initialFuel = 0;
            }
        }
    }

    public double FuelConsumption { get; private set; }

    public double TankCapacity { get; private set; }


    public virtual string Drive(double kilometers, bool withAirConditioner = true)
    {
        double fuelNeed = (FuelConsumption + airConditionerConsumption) * kilometers;

        if (!withAirConditioner)
        {
            fuelNeed = FuelConsumption * kilometers;
        }

        if (InitialFuel < fuelNeed)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        InitialFuel -= fuelNeed;

        return $"{this.GetType().Name} travelled {kilometers} km";
    }
    public virtual string DriveEmpty(double kilometers)
    {
        return Drive(kilometers, false);
    }

    public virtual void Refuel(double liters)
    {
        if (liters > TankCapacity - InitialFuel)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }

        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        InitialFuel += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {InitialFuel:f2}";
    }
}
