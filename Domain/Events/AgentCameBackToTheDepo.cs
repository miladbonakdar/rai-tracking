using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class AgentCameBackToTheDepo : TrackingEvent
    {
        public AgentCameBackToTheDepo(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.AgentCameBackToTheDepo,
                isValidLocation, time, agentLocation)
        {
        }
    }
}