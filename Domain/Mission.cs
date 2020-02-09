using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Mission : AggregateRoot, IAgentTenant
    {
        public int RemainingTime { get; set; }
        public int? OTDR { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public Location FailureLocation { get; set; }
        public string Description { get; set; }

        public int StartOneId { get; set; }
        public Station StartOne { get; set; }

        public int StartTwoId { get; set; }
        public Station StartTwo { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}