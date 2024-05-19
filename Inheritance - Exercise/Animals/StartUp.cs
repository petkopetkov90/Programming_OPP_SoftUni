using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string typeOfAnimal;
            while ((typeOfAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] animalDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (typeOfAnimal)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]);
                            Console.WriteLine(typeOfAnimal);
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]);
                            Console.WriteLine(typeOfAnimal);
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]);
                            Console.WriteLine(typeOfAnimal);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalDetails[0], int.Parse(animalDetails[1]));
                            Console.WriteLine(typeOfAnimal);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalDetails[0], int.Parse(animalDetails[1]));
                            Console.WriteLine(typeOfAnimal);
                            Console.WriteLine(tomcat);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
