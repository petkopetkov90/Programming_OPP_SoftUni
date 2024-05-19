using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models;

public abstract class Diver : IDiver
{
    private string name;
    private int oxygenLevel;
    private List<string> caughtFishes;
    private double competitionPoints;
    private bool hasHealthIssues;

    protected Diver(string name, int oxygenLevel)
    {
        Name = name;
        OxygenLevel = oxygenLevel;
        caughtFishes = new List<string>();
        competitionPoints = 0;
        hasHealthIssues = false;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DiversNameNull);
            }
            name = value;
        }

    }

    public int OxygenLevel
    {
        get => oxygenLevel;
        protected set
        {
            if (value <= 0)
            {
                oxygenLevel = 0;
                HasHealthIssues = true;
            }
            else
            {
                oxygenLevel = value;
            }
        }
    }

    public IReadOnlyCollection<string> Catch => caughtFishes.AsReadOnly();

    public double CompetitionPoints
    {
        get => Math.Round(competitionPoints, 1);
        private set
        {
            competitionPoints = value;
        }
    }

    public bool HasHealthIssues
    {
        get => hasHealthIssues;
        private set
        {
            hasHealthIssues = value;
        }
    }

    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        caughtFishes.Add(fish.Name);
        CompetitionPoints += fish.Points;
    }

    public abstract void Miss(int TimeToCatch);

    public abstract void RenewOxy();

    public void UpdateHealthStatus()
    {
        HasHealthIssues = !HasHealthIssues;
    }

    public override string ToString()
    {
        return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
    }
}
