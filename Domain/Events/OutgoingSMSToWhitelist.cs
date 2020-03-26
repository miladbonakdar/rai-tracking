using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class OutgoingSMSToWhitelist : TrackingEvent
    {
        public OutgoingSMSToWhitelist(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.OutgoingSMSToWhitelist,
                isValidLocation, time, agentLocation)
        {
        }
    }
}