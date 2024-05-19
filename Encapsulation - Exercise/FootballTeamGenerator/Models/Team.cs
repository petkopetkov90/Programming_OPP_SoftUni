
namespace FootballTeamGenerator.Models;

public class Team
{
    private const string MissingPlayerErrorMessage = "Player {0} is not in {1} team.";
    private const string NameErrorMessage = "A name should not be empty.";
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(NameErrorMessage);
            }
            name = value;
        }
    }

    public double Rating
    {
        get
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return Math.Round(players.Average(p => p.Skill));
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player player = players.FirstOrDefault(player => player.Name == playerName);

        if (player == null)
        {
            throw new ArgumentException(string.Format(MissingPlayerErrorMessage, playerName, Name));
        }

        players.Remove(player);
    }
}
