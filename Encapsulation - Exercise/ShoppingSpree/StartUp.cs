using ShoppingSpree.Models;

namespace ShoppingSpree;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] persons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Person> PersonsKVP = new Dictionary<string, Person>();

        for (int i = 0; i < persons.Length; i++)
        {
            string[] personDetails = persons[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
            string personName = personDetails[0];
            decimal personMoney = decimal.Parse(personDetails[1]);

            try
            {
                Person person = new Person(personName, personMoney);
                PersonsKVP.Add(personName, person);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
        }

        string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Product> ProductsKVP = new Dictionary<string, Product>();

        for (int i = 0; i < products.Length; i++)
        {
            string[] productDetails = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
            string productName = productDetails[0];
            decimal productCost = decimal.Parse(productDetails[1]);

            try
            {
                Product product = new Product(productName, productCost);
                ProductsKVP.Add(productName, product);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] shopping = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = PersonsKVP[shopping[0]];
            Product product = ProductsKVP[shopping[1]];

            if (person.Money >= product.Cost)
            {
                person.AddProductToBag(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }

        foreach (KeyValuePair<string, Person> personKVP in PersonsKVP)
        {
            Console.WriteLine(personKVP.Value);
        }
    }
}

