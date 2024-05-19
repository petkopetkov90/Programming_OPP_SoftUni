namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string iD, string birthdate)
    {
        Name = name;
        Age = age;
        Id = iD;
        Birthdate = birthdate;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public string Birthdate { get; private set; }
}
