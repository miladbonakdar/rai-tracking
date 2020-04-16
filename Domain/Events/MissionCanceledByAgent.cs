using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionCanceledByAgent : TrackingEvent
    {
        public MissionCanceledByAgent(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.MissionCanceledByAgent,
                isValidLocation, time, agentLocation)
        {
        }
    }
}