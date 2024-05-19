using Border_Control.Models.Interfaces;

namespace Border_Control.Models;

public class Citizen : ICitizen
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }
}
