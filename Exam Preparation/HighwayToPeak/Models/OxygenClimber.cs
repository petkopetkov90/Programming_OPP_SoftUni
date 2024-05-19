namespace HighwayToPeak.Models;

public class OxygenClimber : Climber
{
    private const int initialStamina = 10;
    private int recoveryIndex = 1;

    public OxygenClimber(string name)
        : base(name, initialStamina)
    {
    }

    public override void Rest(int daysCount)
    {
        Stamina = Stamina + (daysCount * recoveryIndex);
    }
}
