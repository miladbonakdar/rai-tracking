using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class InvalidOutgoingSMS : TrackingEvent
    {
        public InvalidOutgoingSMS(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.InvalidOutgoingSMS,
                isValidLocation, time, agentLocation)
        {
        }
    }
}