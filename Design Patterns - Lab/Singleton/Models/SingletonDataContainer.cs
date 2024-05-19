using Singleton.Models.Interfaces;

namespace Singleton.Models;

public class SingletonDataContainer : ISingletonContainer
{
    private Dictionary<string, int> cities = new Dictionary<string, int>();
    private static SingletonDataContainer instance = new SingletonDataContainer();

    private SingletonDataContainer()
    {
        Console.WriteLine("Initializing singleton object");

        string[] elements = File.ReadAllLines("../../../cities.txt");

        for (int i = 0; i < elements.Length; i += 2)
        {
            cities.Add(elements[i], int.Parse(elements[i + 1]));
        }
    }

    public static SingletonDataContainer Instance => instance;

    public int GetPopulation(string name)
    {
        return cities[name];
    }
}
