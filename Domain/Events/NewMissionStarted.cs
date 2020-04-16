using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class NewMissionStarted : TrackingEvent
    {
        public NewMissionStarted( int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(TrackingEventType.NewMissionStarted, agentId, Dic.AgentEventNames.NewMissionStarted,
                isValidLocation, time, agentLocation)
        {
        }
    }
}