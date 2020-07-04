using System;
using Domain.Enums;
using Domain.ValueObjects;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class SetSettingCommandRequest : ApplicationCommand
    {
        private readonly AgentSetting _setting;
        
        private readonly string _template = 
            "{\"c\":\"{{command}}\",\"aid\":{{adminId}}},\"setting\":{}}";

        public SetSettingCommandRequest(string phoneNumber, int adminId, int agentId,AgentSetting setting)
            : base(CommandType.SetSetting, 
                phoneNumber, adminId, agentId)
        {
            _setting = setting;
        }

        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{adminId}}", AdminId.ToString());
    }
}