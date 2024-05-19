namespace NauticalCatchChallenge.Models;

public class ReefFish : Fish
{
    private const int InitialTimeToCatch = 30;

    public ReefFish(string name, double points)
        : base(name, points, InitialTimeToCatch)
    {
    }
}
