namespace SharedKernel.Exceptions
{
    public class ConflictedException: ExceptionBase
    {
        public ConflictedException(string message = "عملیات مورد نظر قابل اجرا نمی باشد") : base(message)
        {
        }
    }
}