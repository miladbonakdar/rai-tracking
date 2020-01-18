using System;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Command : AggregateRoot , IUserTenant , IAgentTenant
    {
        public CommandType Type { get; set; }
        public DateTime SentAt { get; set; }
        public string CommandData { get; set; }


        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid AgentId { get; set; }
        public virtual Agent Agent { get; set; }
    }
}