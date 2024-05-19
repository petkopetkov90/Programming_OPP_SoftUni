using System.Text;

namespace ShoppingSpree.Models;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        bagOfProducts = new List<Product>();
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
    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(new ErrorMessage().MoneyMessage);
            }
            money = value;
        }
    }

    public void AddProductToBag(Product product)
    {
        bagOfProducts.Add(product);
        Money -= product.Cost;
    }

    public override string ToString()
    {
        if (bagOfProducts.Any())
        {
            return $"{Name} - {string.Join(", ", bagOfProducts)}";
        }

        return $"{Name} - Nothing bought";
    }
}

