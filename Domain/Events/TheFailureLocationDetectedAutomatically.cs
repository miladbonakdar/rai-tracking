using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class TheFailureLocationDetectedAutomatically : TrackingEvent
    {
        public TheFailureLocationDetectedAutomatically(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.TheFailureLocationDetectedAutomatically,
                isValidLocation, time, agentLocation)
        {
        }
    }
}