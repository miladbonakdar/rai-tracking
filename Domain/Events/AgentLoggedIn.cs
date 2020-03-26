using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class AgentLoggedIn : TrackingEvent
    {
        public AgentLoggedIn(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.AgentLoggedIn,
                isValidLocation, time, agentLocation)
        {
        }
    }
}