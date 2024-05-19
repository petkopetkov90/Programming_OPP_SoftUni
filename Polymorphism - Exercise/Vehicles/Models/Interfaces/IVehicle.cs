
namespace Vehicles.Models.interfaces;

public interface IVehicle
{

    string Drive(double kilometers, bool withAirConditioner = true);

    string DriveEmpty(double kilometers);

    void Refuel(double liters);
}
