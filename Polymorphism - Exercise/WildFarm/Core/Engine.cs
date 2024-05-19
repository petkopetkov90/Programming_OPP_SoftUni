
using System.Data;
using WildFarm.Core.Interfaces;
using WildFarm.Exceptions;
using WildFarm.Factories.Interaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;
    }

    public void Start()
    {
        ICollection<IAnimal> animals = new List<IAnimal>();

        string input;
        while((input = reader.ReadLine()) != "End")
        {
            string[] animalDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] foodDetails = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                IAnimal animal = animalFactory.CreateAnimal(animalDetails);
                IFood food = foodFactory.CreateFood(foodDetails);
                animals.Add(animal);
                writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);
            }
            catch (NotEatableFoodException exception)
            {
                writer.WriteLine(exception.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        foreach (IAnimal animal in animals)
        {
            writer.WriteLine(animal);
        }
    }
}
