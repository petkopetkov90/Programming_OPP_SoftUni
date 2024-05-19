using FootballTeamGenerator.Models;

namespace FootballTeamGenerator;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputDetails = input.Split(";");

            try
            {
                if (inputDetails[0] == "Team")
                {
                    Team team = new Team(inputDetails[1]);
                    teams.Add(team);
                }
                else
                {
                    Team currentTeam = teams.FirstOrDefault(t => t.Name == inputDetails[1]);

                    if (currentTeam == null)
                    {
                        Console.WriteLine($"Team {inputDetails[1]} does not exist.");
                        continue;
                    }

                    if (inputDetails[0] == "Add")
                    {
                        Player player = new Player(inputDetails[2], int.Parse(inputDetails[3]), int.Parse(inputDetails[4]), int.Parse(inputDetails[5]), int.Parse(inputDetails[6]), int.Parse(inputDetails[7]));

                        currentTeam.AddPlayer(player);
                    }
                    else if (inputDetails[0] == "Remove")
                    {
                        currentTeam.RemovePlayer(inputDetails[2]);
                    }
                    else if (inputDetails[0] == "Rating")
                    {
                        Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

