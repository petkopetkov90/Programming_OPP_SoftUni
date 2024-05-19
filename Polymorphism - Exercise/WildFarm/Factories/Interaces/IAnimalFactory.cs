
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalDetails);
}
