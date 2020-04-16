using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class GotOutOfDepoZone : TrackingEvent
    {
        public GotOutOfDepoZone(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.GotOutOfDepoZone,
                isValidLocation, time, agentLocation)
        {
        }
    }
}