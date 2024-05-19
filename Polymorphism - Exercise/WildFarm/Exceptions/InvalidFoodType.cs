
namespace WildFarm.Exceptions
{
    public class InvalidFoodType : Exception
    {
        private const string message = "Invalid Food Type!";

        public InvalidFoodType()
            : base(message)
        {
        }
    }
}
