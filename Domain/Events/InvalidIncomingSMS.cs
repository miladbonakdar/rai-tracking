using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class InvalidIncomingSMS : TrackingEvent
    {
        public InvalidIncomingSMS(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.InvalidIncomingSMS,
                isValidLocation, time, agentLocation)
        {
        }
    }
}