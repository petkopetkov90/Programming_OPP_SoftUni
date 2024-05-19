namespace NauticalCatchChallenge.Models;

public class FreeDiver : Diver
{
    private const int InitialOxygenLevel = 120;
    public FreeDiver(string name)
        : base(name, InitialOxygenLevel)
    {
    }

    public override void Miss(int TimeToCatch)
    {
        OxygenLevel -= (int)Math.Round(TimeToCatch * 0.60, MidpointRounding.AwayFromZero);
    }

    public override void RenewOxy()
    {
        OxygenLevel = InitialOxygenLevel;
    }
}
