using System;
using Domain.Enums;
using SharedKernel;

namespace Domain
{
    public class AgentEvent : Event
    {
        public AgentEvent(int agentId, TrackingEventType eventType, DateTime occurredAt) 
            : base(agentId, eventType, occurredAt)
        {
        }
    }
}