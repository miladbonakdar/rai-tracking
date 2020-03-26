using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class TheAgentIsInFailureZone : TrackingEvent
    {
        public TheAgentIsInFailureZone(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.TheAgentIsInFailureZone,
                isValidLocation, time, agentLocation)
        {
        }
    }
}