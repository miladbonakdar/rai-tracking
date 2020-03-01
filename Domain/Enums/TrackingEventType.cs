using System.ComponentModel;
using SharedKernel.Constants;

namespace Domain.Enums
{
    public enum TrackingEventType
    {
        [Description(Dic.AgentEventNames.NewMissionStarted)]
        NewMissionStarted = 1,

        [Description(Dic.AgentEventNames.MissionCanceledFromServer)]
        MissionCanceledFromServer = 2,

        [Description(Dic.AgentEventNames.TheAgentIsInFailureZone)]
        TheAgentIsInFailureZone = 3,

        [Description(Dic.AgentEventNames.TheAgentFoundTheFailureLocation)]
        TheAgentFoundTheFailureLocation = 4,

        [Description(Dic.AgentEventNames.GpsIsTurnedOff)]
        GpsIsTurnedOff = 5,

        [Description(Dic.AgentEventNames.GpsIsTurnedOn)]
        GpsIsTurnedOn = 6,

        [Description(Dic.AgentEventNames.GpsIsStillOff)]
        GpsIsStillOff = 7,

        [Description(Dic.AgentEventNames.MissionTimedOut)]
        MissionTimedOut = 8,

        [Description(Dic.AgentEventNames.LowBattery)]
        LowBattery = 9,

        [Description(Dic.AgentEventNames.LowSpeed)]
        LowSpeed = 10,

        [Description(Dic.AgentEventNames.GotOutOfFailureZone)]
        GotOutOfFailureZone = 11,

        [Description(Dic.AgentEventNames.GotOutOfDepoZone)]
        GotOutOfDepoZone = 12,

        [Description(Dic.AgentEventNames.ResumedAfterPhoneRestart)]
        ResumedAfterPhoneRestart = 13,

        [Description(Dic.AgentEventNames.MissionFinishedAutomatically)]
        MissionFinishedAutomatically = 14,

        [Description(Dic.AgentEventNames.TheFailureLocationDetectedAutomatically)]
        TheFailureLocationDetectedAutomatically = 15,

        [Description(Dic.AgentEventNames.IncomingCallFromWhitelist)]
        IncomingCallFromWhitelist = 16,

        [Description(Dic.AgentEventNames.OutgoingCallToWhitelist)]
        OutgoingCallToWhitelist = 17,

        [Description(Dic.AgentEventNames.InvalidIncomingCall)]
        InvalidIncomingCall = 18,

        [Description(Dic.AgentEventNames.InvalidOutgoingCall)]
        InvalidOutgoingCall = 19,

        [Description(Dic.AgentEventNames.IncomingSMSFromWhitelist)]
        IncomingSMSFromWhitelist = 20,

        [Description(Dic.AgentEventNames.OutgoingSMSToWhitelist)]
        OutgoingSMSToWhitelist = 21,

        [Description(Dic.AgentEventNames.InvalidIncomingSMS)]
        InvalidIncomingSMS = 22,

        [Description(Dic.AgentEventNames.InvalidOutgoingSMS)]
        InvalidOutgoingSMS = 23,

        [Description(Dic.AgentEventNames.AgentLoggedOut)]
        AgentLoggedOut = 24,

        [Description(Dic.AgentEventNames.AgentLoggedIn)]
        AgentLoggedIn = 25,

        [Description(Dic.AgentEventNames.AgentIsNotMoving)]
        AgentIsNotMoving = 26,

        [Description(Dic.AgentEventNames.AgentCameBackToTheDepo)]
        AgentCameBackToTheDepo = 27,

        [Description(Dic.AgentEventNames.OTDRTestCaptured)]
        OTDRTestCaptured = 28,

        [Description(Dic.AgentEventNames.OTDRTestIsNotCaptured)]
        OTDRTestIsNotCaptured = 29,

        [Description(Dic.AgentEventNames.TheAgentStartMoving)]
        TheAgentStartMoving = 30,

        [Description(Dic.AgentEventNames.MissionEdited)]
        MissionEdited = 31,

        [Description(Dic.AgentEventNames.MissionFinished)]
        MissionFinished = 32,

        [Description(Dic.AgentEventNames.MissionCanceledByAgent)]
        MissionCanceledByAgent = 33,

        [Description(Dic.AgentEventNames.StatusCaptured)]
        StatusCaptured = 34,
    }
}