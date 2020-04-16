using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class StatusCaptured : TrackingEvent
    {
        public StatusCaptured(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.StatusCaptured,
                isValidLocation, time, agentLocation)
        {
        }
    }
}