using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public class Command : AggregateRoot, IAgentTenant
    {
        public Command(int agentId, CommandType type, DateTime sentAt)
        {
            Type = type;
            SentAt = sentAt;
            AgentId = agentId;
        }

        private Command()
        {
        }

        public void SetData([NotNull] string data) => CommandData = data ?? throw new ArgumentNullException();

        public CommandType Type { get; private set; }
        public DateTime SentAt { get; private set; }
        [Required] public string CommandData { get; private set; }

        public int AgentId { get; private set; }
        public Agent Agent { get; private set; }
    }
}