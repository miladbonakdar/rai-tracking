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
        
        protected ApplicationCommand(CommandType commandType, string phoneNumber,
            int adminId, int agentId)
        {
            CommandType = commandType;
            PhoneNumber = phoneNumber;
            AdminId = adminId;
            AgentId = agentId;
        }

        protected abstract string GenerateMessage();
        public string PhoneNumber { get; }
        public CommandType CommandType { get; }
        public int AdminId { get; }
        public int AgentId { get; }
        public string Message => GenerateMessage();
    }
}