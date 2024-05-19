
namespace Telephony;

public class Smartphone : IStationaryPhone, ISmartphone
{

    public void Call(string phoneNumber)
    {
        if (phoneNumber.Any(ch => !char.IsDigit(ch)))
        {
            throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Calling... {phoneNumber}");
    }

    public void Browse(string Url)
    {
        if (Url.Any(ch => char.IsDigit(ch)))
        {
            throw new ArgumentException("Invalid URL!");
        }

        Console.WriteLine($"Browsing: {Url}!");
    }
}
