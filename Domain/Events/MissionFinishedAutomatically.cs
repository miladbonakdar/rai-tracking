using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionFinishedAutomatically : TrackingEvent
    {
        public MissionFinishedAutomatically(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.MissionFinishedAutomatically,
                isValidLocation, time, agentLocation)
        {
        }
    }
}