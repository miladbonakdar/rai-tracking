using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class GpsIsStillOff : TrackingEvent
    {
        public GpsIsStillOff(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.GpsIsStillOff,
                isValidLocation, time, agentLocation)
        {
        }
    }
}