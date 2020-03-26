using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class ResumedAfterPhoneRestart : TrackingEvent
    {
        public ResumedAfterPhoneRestart(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.ResumedAfterPhoneRestart,
                isValidLocation, time, agentLocation)
        {
        }
    }
}