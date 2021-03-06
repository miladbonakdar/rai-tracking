﻿using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class LowSpeed : TrackingEvent
    {
        public LowSpeed(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null) 
            : base(eventType, agentId, Dic.AgentEventNames.LowSpeed,
                isValidLocation, time, agentLocation)
        {
        }
    }
}