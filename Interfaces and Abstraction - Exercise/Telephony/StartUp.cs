namespace Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        List<string> phoneNumbers = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

        List<string> webAddresses = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

        IStationaryPhone phone;

        foreach (string phoneNumber in phoneNumbers)
        {
            if (phoneNumber.Length == 10)
            {
                phone = new Smartphone();
            }
            else
            {
                phone = new StationaryPhone();
            }

            try
            {
                phone.Call(phoneNumber);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        ISmartphone smartphone = new Smartphone();

        foreach (string webAddress in webAddresses)
        {

            try
            {
                smartphone.Browse(webAddress);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
