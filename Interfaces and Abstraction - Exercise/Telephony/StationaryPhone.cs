
namespace Telephony;

public class StationaryPhone : IStationaryPhone
{
    public void Call(string phoneNumber)
    {
        if (phoneNumber.Any(ch => !char.IsDigit(ch)))
        {
            throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Dialing... {phoneNumber}");
    }
}
