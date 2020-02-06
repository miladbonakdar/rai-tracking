namespace SharedKernel.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public string Id { get; }
        public NotFoundException(string id = default, string message = "مورد یافت نشد") : base(message)
        {
            Id = id;
        }

    }
}