using System;
using Domain.Enums;
using Domain.Interfaces;
using SharedKernel;

namespace Domain
{
    public class MissionEvent : Event, IMission
    {
        private MissionEvent()
        {
        }

        public int MissionId { get; private set; }
        public Mission Mission { get; set; }

        public MissionEvent(int missionId, int agentId, TrackingEventType eventType, DateTime occurredAt)
            : base(agentId, eventType, occurredAt)
        {
            MissionId = missionId;
        }
    }
}