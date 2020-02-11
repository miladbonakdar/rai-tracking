using System;
using Domain.Enums;
using SharedKernel;

namespace Domain.Commands
{
    public class SetSettingCommandRequest : ApplicationCommand
    {
        protected SetSettingCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.SetSetting, Dic.CommandNames.SetSetting, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}