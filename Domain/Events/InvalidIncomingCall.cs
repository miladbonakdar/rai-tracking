using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class InvalidIncomingCall : TrackingEvent
    {
        public InvalidIncomingCall(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.InvalidIncomingCall,
                isValidLocation, time, agentLocation)
        {
        }
    }
}