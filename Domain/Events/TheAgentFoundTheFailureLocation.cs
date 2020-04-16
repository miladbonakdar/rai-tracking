using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class TheAgentFoundTheFailureLocation : TrackingEvent
    {
        public TheAgentFoundTheFailureLocation(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.TheAgentFoundTheFailureLocation,
                isValidLocation, time, agentLocation)
        {
        }
    }
}