using System;
using Domain.Interfaces;
using SharedKernel.Interfaces;

namespace Domain.Events
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