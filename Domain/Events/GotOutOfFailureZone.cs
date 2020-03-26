using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class GotOutOfFailureZone : TrackingEvent
    {
        public GotOutOfFailureZone(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.GotOutOfFailureZone,
                isValidLocation, time, agentLocation)
        {
        }
    }
}