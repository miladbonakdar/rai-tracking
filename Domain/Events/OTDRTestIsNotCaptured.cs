using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class OTDRTestIsNotCaptured : TrackingEvent
    {
        public OTDRTestIsNotCaptured(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.OTDRTestIsNotCaptured,
                isValidLocation, time, agentLocation)
        {
        }
    }
}