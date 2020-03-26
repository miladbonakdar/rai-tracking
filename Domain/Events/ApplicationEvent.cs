using System;
using Domain.Interfaces;

namespace Domain.Events
{
    public abstract class ApplicationEvent : IApplicationEvent
    {
        protected ApplicationEvent(string name = null, DateTime? occurredAt = null)
        {
            OccurredAt = occurredAt ?? DateTime.Now;
            Name = name ?? GetType().Name;
        }

        public DateTime OccurredAt { get; }
        public string Name { get; }
    }
}