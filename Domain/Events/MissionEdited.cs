﻿using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel.Constants;

namespace Domain.Events
{
    public class MissionEdited : TrackingEvent
    {
        public MissionEdited(TrackingEventType eventType, int agentId
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(eventType, agentId, Dic.AgentEventNames.MissionEdited,
                isValidLocation, time, agentLocation)
        {
        }
    }
}