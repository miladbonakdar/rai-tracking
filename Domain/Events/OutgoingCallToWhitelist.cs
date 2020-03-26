using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class OutgoingCallToWhitelist : TrackingEvent
    {
        public OutgoingCallToWhitelist(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.OutgoingCallToWhitelist,
                isValidLocation, time, agentLocation)
        {
        }
    }
}