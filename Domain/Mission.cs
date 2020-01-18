using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Mission : AggregateRoot, IUserTenant, IAgentTenant
    {
        public int RemainingTime { get; set; }
        public int? OTDR { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public Location FailureLocation { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid StartOneId { get; set; }
        public Station StartOne { get; set; }

        public Guid StartTwoId { get; set; }    
        public Station StartTwo { get; set; }

        public Guid AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}
