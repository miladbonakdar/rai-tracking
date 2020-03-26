using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class LowBattery : TrackingEvent
    {
        public LowBattery(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.LowBattery,
                isValidLocation, time, agentLocation)
        {
        }
    }
}