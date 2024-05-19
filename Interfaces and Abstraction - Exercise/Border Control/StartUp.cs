using Border_Control.Models;
using Border_Control.Models.Interfaces;

namespace BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> subjects = new List<IIdentifiable>();

        string input;
        while((input = Console.ReadLine()) != "End")
        {
            string[] details = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IIdentifiable subject = null;

            if (details.Length == 3 )
            {
                subject = new Citizen(details[0], int.Parse(details[1]), details[2]);
            }
            else
            {
                subject = new Robot(details[0], details[1]);
            }

            subjects.Add(subject);
        }

        string lastDigitOfFakeId = Console.ReadLine();

        List<IIdentifiable> detainedSubjects = subjects.FindAll(s => s.Id.EndsWith(lastDigitOfFakeId));

        foreach (IIdentifiable subject in detainedSubjects)
        {
            Console.WriteLine(subject.Id);
        }
    }
}
