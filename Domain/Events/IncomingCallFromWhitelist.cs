using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class IncomingCallFromWhitelist : TrackingEvent
    {
        public IncomingCallFromWhitelist(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.IncomingCallFromWhitelist,
                isValidLocation, time, agentLocation)
        {
        }
    }
}