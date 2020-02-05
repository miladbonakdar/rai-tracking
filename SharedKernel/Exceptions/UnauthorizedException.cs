namespace SharedKernel.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public UnauthorizedException(string message = "Unauthorized") : base(message)
        {
        }
    }
}