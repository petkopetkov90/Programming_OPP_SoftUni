
namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double initialFuel, double fuelConsumption, double tankCapacity) 
            : base(initialFuel, fuelConsumption, tankCapacity, AirConditionerConsumption)
        {
        }

    }
}
