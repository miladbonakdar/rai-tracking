using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionCanceledFromServer : TrackingEvent
    {
        public MissionCanceledFromServer(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.MissionCanceledFromServer,
                isValidLocation, time, agentLocation)
        {
        }
    }
}