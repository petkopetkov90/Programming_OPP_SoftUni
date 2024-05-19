using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public class BaseCamp : IBaseCamp
{
    private SortedSet<string> baseCamp;

    public BaseCamp()
    {
        baseCamp = new SortedSet<string>();
    }

    public IReadOnlyCollection<string> Residents => baseCamp.ToList().AsReadOnly();

    public void ArriveAtCamp(string climberName)
    {
        baseCamp.Add(climberName);
    }

    public void LeaveCamp(string climberName)
    {
        baseCamp.Remove(climberName);
    }
}
