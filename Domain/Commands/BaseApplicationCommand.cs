using System;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Commands
{
    public abstract class ApplicationCommand : IApplicationCommand
    {
        protected ApplicationCommand(CommandType commandType, string name, string phoneNumber, string createdBy,
            int? adminId, int agentId)
        {
            CreatedAt = DateTime.Now;
            CommandType = commandType;
            PhoneNumber = phoneNumber;
            CreatedBy = createdBy;
            AdminId = adminId;
            AgentId = agentId;
            Name = name;
        }

        protected abstract string GenerateMessage();

        public DateTime CreatedAt { get; }
        public string PhoneNumber { get; }
        public CommandType CommandType { get; }
        public string CreatedBy { get; }
        public int? AdminId { get; }
        public int AgentId { get; }
        public string Name { get; }
        public string Message => GenerateMessage();
    }
}