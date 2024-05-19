namespace HighwayToPeak.Models;

internal class NaturalClimber : Climber
{
    private const int initialStamina = 6;
    private int recoveryIndex = 2;

    public NaturalClimber(string name)
        : base(name, initialStamina)
    {
    }

    public override void Rest(int daysCount)
    {
        Stamina = Stamina + (daysCount * recoveryIndex);
    }
}
