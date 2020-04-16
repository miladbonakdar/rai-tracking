﻿using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class GpsIsTurnedOff : TrackingEvent
    {
        public GpsIsTurnedOff(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.GpsIsTurnedOff,
                isValidLocation, time, agentLocation)
        {
        }
    }
}