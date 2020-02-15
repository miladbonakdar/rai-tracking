using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public abstract class Event : Entity, IAgentTenant
    {
        public DateTime OccurredAt { get; set; }
        public TrackingEventType EventType { get; set; }
        public Location AgentLocation { get; set; }
        public bool IsValidLocation { get; set; }
        public bool Seen { get; set; }
        [Required]
        public string EventData { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}