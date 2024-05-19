
namespace FootballTeamGenerator.Models;

public class Player
{
    private const string StatsErrorMessage = "{0} should be between 0 and 100.";
    private const string NameErrorMessage = "A name should not be empty.";
    private const int MinStats = 0;
    private const int MaxStats = 100;
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
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

    public int Endurance
    {
        get => endurance;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(StatsErrorMessage, nameof(Endurance)));
            }
            endurance = value;
        }
    }
    public int Sprint
    {
        get => sprint;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(StatsErrorMessage, nameof(Sprint)));
            }
            sprint = value;
        }
    }
    public int Dribble
    {
        get => dribble;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(StatsErrorMessage, nameof(Dribble)));
            }
            dribble = value;
        }
    }
    public int Passing
    {
        get => passing;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(StatsErrorMessage, nameof(Passing)));
            }
            passing = value;
        }
    }
    public int Shooting
    {
        get => shooting;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(StatsErrorMessage, nameof(Shooting)));
            }
            shooting = value;
        }
    }

    public double Skill => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.00;
}
