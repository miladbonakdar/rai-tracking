using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class IncomingSMSFromWhitelist : TrackingEvent
    {
        public IncomingSMSFromWhitelist(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.IncomingSMSFromWhitelist,
                isValidLocation, time, agentLocation)
        {
        }
    }
}