using CommandPattern.Models;
using CommandPattern.Models.Interfaces;

namespace CommandPattern;

public class StartUp
{
    static void Main()
    {
        ModifyPrice modifyPrice = new ModifyPrice();
        Product product = new Product("Phone", 500);

        Exectute(modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 100));
        Exectute(modifyPrice, new ProductCommand(product, Enums.PriceAction.Decrease, 200));

        Console.WriteLine(product);
    }

    private static void Exectute(ModifyPrice modifyPrice, ICommand command)
    {
        modifyPrice.SetCommand(command);
        modifyPrice.Invoke();
    }
}
