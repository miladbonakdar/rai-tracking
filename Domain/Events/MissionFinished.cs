using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionFinished : TrackingEvent
    {
        public MissionFinished(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.MissionFinished,
                isValidLocation, time, agentLocation)
        {
        }
    }
}