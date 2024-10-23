
namespace pratice_isin.Domain.Exceptions
{

    public class InvalidCodeException : Exception
    {
        private const string message = "Invalid code";

        public InvalidCodeException() : base(message)
        {
        }
    }
}
