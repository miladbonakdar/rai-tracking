using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class TheAgentStartMoving : TrackingEvent
    {
        public TheAgentStartMoving(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.TheAgentStartMoving,
                isValidLocation, time, agentLocation)
        {
        }
    }
}