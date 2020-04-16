using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class InvalidOutgoingCall : TrackingEvent
    {
        public InvalidOutgoingCall(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.InvalidOutgoingCall,
                isValidLocation, time, agentLocation)
        {
        }
    }
}