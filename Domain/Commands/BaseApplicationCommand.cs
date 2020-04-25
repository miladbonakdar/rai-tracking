using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Commands
{
    public abstract class ApplicationCommand : IApplicationCommand
    {
        protected static readonly Dictionary<CommandType,string> Map = new Dictionary<CommandType, string>();
        static ApplicationCommand()
        {
            Map.Add(CommandType.NewMission,"NEW");
            Map.Add(CommandType.CancelMission,"CANCEL");
            Map.Add(CommandType.EditMission,"EDIT");
            Map.Add(CommandType.FinishMission,"FINISH");
            Map.Add(CommandType.SetSetting,"SETTING");
            Map.Add(CommandType.UpdateStatus,"STATUS");
            Map.Add(CommandType.SetOtdrValue,"OTDR");
        }
        
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