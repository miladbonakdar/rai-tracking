using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class AgentLoggedOut : TrackingEvent
    {
        public AgentLoggedOut(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.AgentLoggedOut,
                isValidLocation, time, agentLocation)
        {
        }
    }
}