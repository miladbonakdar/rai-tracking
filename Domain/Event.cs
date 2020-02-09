using System;
using System.Dynamic;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public abstract class Event : Entity, IAgentTenant
    {
        public DateTime OccurredAt { get; set; }
        public EventType EventType { get; set; }
        public Location AgentLocation { get; set; }
        public bool IsValidLocation { get; set; }
        public bool HasSeen { get; set; }
        public string EventData { get; set; }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
    }
}