
using WildFarm.Exceptions;
using WildFarm.Factories.Interaces;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal CreateAnimal(string[] animalDetails)
    {
        string type = animalDetails[0];
        string name = animalDetails[1];
        double weight = double.Parse(animalDetails[2]);

        switch (type)
        {
            case "Owl":
                double owlWingSize = double.Parse(animalDetails[3]);
                return new Owl(name, weight, owlWingSize);
            case "Hen":
                double henWingSize = double.Parse(animalDetails[3]);
                return new Hen(name, weight, henWingSize);
            case "Mouse":
                string mouseLivingRegion = animalDetails[3];
                return new Mouse(name, weight, mouseLivingRegion);
            case "Dog":
                string dogLivingRegion = animalDetails[3];
                return new Dog(name, weight, dogLivingRegion);
            case "Cat":
                string catLivingRegion = animalDetails[3];
                string catBreed = animalDetails[4];
                return new Cat(name, weight, catLivingRegion, catBreed);
            case "Tiger":
                string tigerLivingRegion = animalDetails[3];
                string tigerBreed = animalDetails[4];
                return new Tiger(name, weight, tigerLivingRegion, tigerBreed);
            default:
                throw new InvalidAnimalType();
        }
    }
}
