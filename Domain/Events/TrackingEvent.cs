using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using Domain.ValueObjects;
using JetBrains.Annotations;

namespace Domain.Events
{
    public abstract class TrackingEvent : ApplicationEvent
    {
        protected TrackingEvent(TrackingEventType eventType, int agentId, [NotNull] string name
            , bool isValidLocation, DateTime time, Location agentLocation = null)
            : base(name, time)
        {
            EventType = eventType;
            AgentId = agentId;
            IsValidLocation = isValidLocation;
            AgentLocation = agentLocation;
            IsMissionEvent = MissionTrackingEventTypes.Contains(EventType);
            IsUserEvent = UserTrackingEventTypes.Contains(EventType);
            IsAlarm = AlarmTrackingEventTypes.Contains(EventType);
        }

        public bool IsAlarm { get; }
        public int AgentId { get; }
        public TrackingEventType EventType { get; }
        public Location AgentLocation { get; }
        public bool IsValidLocation { get; }

        public bool IsMissionEvent { get; }

        public bool IsUserEvent { get; }

        public static readonly IEnumerable<TrackingEventType> UserTrackingEventTypes = new[]
        {
            TrackingEventType.GpsIsTurnedOff,
            TrackingEventType.GpsIsTurnedOn,
            TrackingEventType.GpsIsStillOff,
            TrackingEventType.LowBattery,
            TrackingEventType.GotOutOfDepoZone,
            TrackingEventType.IncomingCallFromWhitelist,
            TrackingEventType.OutgoingCallToWhitelist,
            TrackingEventType.InvalidIncomingCall,
            TrackingEventType.InvalidOutgoingCall,
            TrackingEventType.IncomingSMSFromWhitelist,
            TrackingEventType.OutgoingSMSToWhitelist,
            TrackingEventType.InvalidIncomingSMS,
            TrackingEventType.InvalidOutgoingSMS,
            TrackingEventType.AgentLoggedOut,
            TrackingEventType.AgentLoggedIn,
            TrackingEventType.AgentCameBackToTheDepo,
            TrackingEventType.StatusCaptured
        };

        public static readonly IEnumerable<TrackingEventType> MissionTrackingEventTypes = new[]
        {
            TrackingEventType.NewMissionStarted,
            TrackingEventType.MissionCanceledFromServer,
            TrackingEventType.TheAgentIsInFailureZone,
            TrackingEventType.TheAgentFoundTheFailureLocation,
            TrackingEventType.GpsIsTurnedOff,
            TrackingEventType.GpsIsTurnedOn,
            TrackingEventType.GpsIsStillOff,
            TrackingEventType.MissionTimedOut,
            TrackingEventType.LowBattery,
            TrackingEventType.LowSpeed,
            TrackingEventType.GotOutOfFailureZone,
            TrackingEventType.ResumedAfterPhoneRestart,
            TrackingEventType.MissionFinishedAutomatically,
            TrackingEventType.TheFailureLocationDetectedAutomatically,
            TrackingEventType.AgentIsNotMoving,
            TrackingEventType.OTDRTestCaptured,
            TrackingEventType.OTDRTestIsNotCaptured,
            TrackingEventType.TheAgentStartMoving,
            TrackingEventType.MissionEdited,
            TrackingEventType.MissionFinished,
            TrackingEventType.MissionCanceledByAgent,
        };

        public static readonly IEnumerable<TrackingEventType> AlarmTrackingEventTypes = new[]
        {
            TrackingEventType.GpsIsTurnedOff,
            TrackingEventType.GpsIsStillOff,
            TrackingEventType.MissionTimedOut,
            TrackingEventType.LowBattery,
            TrackingEventType.LowSpeed,
            TrackingEventType.GotOutOfFailureZone,
            TrackingEventType.ResumedAfterPhoneRestart,
            TrackingEventType.AgentIsNotMoving,
            TrackingEventType.OTDRTestIsNotCaptured,
            TrackingEventType.MissionCanceledByAgent, TrackingEventType.GpsIsTurnedOff,
            TrackingEventType.GotOutOfDepoZone,
            TrackingEventType.InvalidIncomingCall,
            TrackingEventType.InvalidOutgoingCall,
            TrackingEventType.InvalidIncomingSMS,
            TrackingEventType.InvalidOutgoingSMS,
            TrackingEventType.AgentLoggedOut
        };
    }
}