namespace SharedKernel.Exceptions
{
    public class ForbiddenException : ExceptionBase
    {
        public ForbiddenException(string message = "شما مجوز دسترسی ندارید") : base(message)
        {
        }
    }
}