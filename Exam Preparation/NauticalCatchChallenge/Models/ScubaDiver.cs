namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int InitialOxygenLevel = 540;
        public ScubaDiver(string name)
            : base(name, InitialOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.30, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = InitialOxygenLevel;
        }
    }
}
