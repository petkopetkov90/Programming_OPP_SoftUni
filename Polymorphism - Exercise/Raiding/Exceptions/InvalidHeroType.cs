
namespace Raiding.Exceptions
{
    public class InvalidHeroType : Exception
    {
        private const string message = "Invalid hero!";
        public InvalidHeroType() 
            : base(message)
        {

        }
    }
}
