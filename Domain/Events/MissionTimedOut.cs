using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionTimedOut : TrackingEvent
    {
        public MissionTimedOut(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.MissionTimedOut,
                isValidLocation, time, agentLocation)
        {
        }
    }
}