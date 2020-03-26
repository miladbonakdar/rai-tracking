using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class AgentIsNotMoving : TrackingEvent
    {
        public AgentIsNotMoving(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.AgentIsNotMoving,
                isValidLocation, time, agentLocation)
        {
        }
    }
}