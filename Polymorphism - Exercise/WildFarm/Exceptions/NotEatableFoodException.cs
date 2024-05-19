
namespace WildFarm.Exceptions
{
    public class NotEatableFoodException : Exception
    {
        public NotEatableFoodException(string? message) 
            : base(message)
        {
        }
    }
}
