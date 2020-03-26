using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class GpsIsTurnedOn : TrackingEvent
    {
        public GpsIsTurnedOn(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.GpsIsTurnedOn,
                isValidLocation, time, agentLocation)
        {
        }
    }
}