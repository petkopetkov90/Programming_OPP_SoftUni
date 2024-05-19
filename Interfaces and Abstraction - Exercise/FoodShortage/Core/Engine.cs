
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Engines;

public class Engine
{
    public void Start()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());

        Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] details = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = details[0];

            IBuyer buyer;

            if (details.Length == 4)
            {
                buyer = new Citizen(details[0], int.Parse(details[1]), details[2], details[3]);
            }
            else
            {
                buyer = new Rebel(details[0], int.Parse(details[1]), details[2]);
            }

            buyers.Add(name, buyer);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string name = input;

            if (buyers.ContainsKey(name))
            {
               buyers[name].BuyFood();
            }
        }

        int foodPurchased = buyers.Values.Sum(b => b.Food);
        Console.WriteLine(foodPurchased);
    }

}
