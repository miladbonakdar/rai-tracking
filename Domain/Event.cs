using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public abstract class Event : Entity, IAgentTenant
    {
        protected Event(int agentId, TrackingEventType eventType, DateTime occurredAt)
        {
            EventType = eventType;
            OccurredAt = occurredAt;
            AgentId = agentId;
            Seen = false;
            IsAlarm = TrackingEvent.AlarmTrackingEventTypes.Contains(EventType);
        }

        protected Event()
        {
        }

        public void SetLocation([NotNull] Location location, bool isValid = true)
            => (AgentLocation, IsValidLocation) = (location ?? throw new ArgumentNullException(), isValid);

        public void SetData(string data)
            => EventData = data;

        public DateTime OccurredAt { get; private set; }
        public TrackingEventType EventType { get; private set; }
        public Location AgentLocation { get; private set; }
        public bool IsValidLocation { get; private set; }
        public bool IsAlarm { get; private set; }
        public bool Seen { get; private set; }
        [Required] public string EventData { get; private set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}