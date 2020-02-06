using System;

namespace SharedKernel.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public DateTime Time { get; }
        protected ExceptionBase(string message) : base(message)
        {
            Time = DateTime.Now;
        }
    }
}
