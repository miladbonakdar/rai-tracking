namespace SharedKernel.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public string Key { get; }
        public BadRequestException(string key = default, string message = "درخواست شما نا معتبر می باشد") : base(message)
        {
            Key = key;
        }

    }
}