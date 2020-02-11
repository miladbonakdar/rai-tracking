using System;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string CommandData { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}