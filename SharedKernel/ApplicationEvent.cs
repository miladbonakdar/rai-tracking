using System;
using SharedKernel.Interfaces;

namespace SharedKernel
{
    public abstract class ApplicationEvent : IApplicationEvent
    {
        protected ApplicationEvent()
        {
            OccurredAt = DateTime.Now;
            Name = GetType().Name;
        }

        public DateTime OccurredAt { get; }
        public string Name { get; }
    }
}