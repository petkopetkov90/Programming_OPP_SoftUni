namespace ShoppingSpree.Models;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(new ErrorMessage().NameMessage);
            }
            name = value;
        }
    }
    public decimal Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(new ErrorMessage().MoneyMessage);
            }
            cost = value;
        }
    }

    public override string ToString() => Name;
}