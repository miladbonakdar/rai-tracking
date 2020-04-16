using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class OTDRTestCaptured : TrackingEvent
    {
        public OTDRTestCaptured(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.OTDRTestCaptured,
                isValidLocation, time, agentLocation)
        {
        }
    }
}