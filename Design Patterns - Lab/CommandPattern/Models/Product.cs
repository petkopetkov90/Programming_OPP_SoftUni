namespace CommandPattern.Models;

public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }

    public void IncreasePrice(decimal amount)
    {
        Price += amount;
        Console.WriteLine($"The price for the {Name} have been increased by {amount}$.");
    }

    public void DecreasePrice(decimal amount)
    {
        if (amount < Price)
        {
            Price -= amount;
            Console.WriteLine($"The price for the {Name} have been increased by {amount}$.");
        }
        else
        {
            throw new ArgumentException("The price can't be null or negative");
        }
    }

    public override string ToString() => $"Current price for the {Name} product is {Price}$.";
}
