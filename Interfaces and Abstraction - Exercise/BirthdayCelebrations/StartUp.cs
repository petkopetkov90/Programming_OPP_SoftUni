
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Engines;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();
        engine.Start();
        //List<IBirthable> birthableSubjects = new List<IBirthable>();

        //string input;
        //while ((input = Console.ReadLine()) != "End")
        //{
        //    string[] details = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        //    IBirthable subject = null;

        //    if (details[0] == "Citizen")
        //    {
        //        subject = new Citizen(details[1], int.Parse(details[2]), details[3], details[4]);
        //    }
        //    else if (details[0] == "Pet")
        //    {
        //        subject = new Pet(details[1], details[2]);
        //    }
        //    else
        //    {
        //        continue;
        //    }

        //    birthableSubjects.Add(subject);
        //}

        //string year = Console.ReadLine();

        //foreach (var subject in birthableSubjects)
        //{
        //    if (subject.Birthdate.EndsWith(year))
        //    {
        //        Console.WriteLine(subject.Birthdate);
        //    }
        //}
    }
}
