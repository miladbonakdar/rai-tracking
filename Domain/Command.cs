using System;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Command : AggregateRoot , IAgentTenant
    {
        public CommandType Type { get; set; }
        public DateTime SentAt { get; set; }
        public string CommandData { get; set; }
        public string Number { get; set; }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
    }
}