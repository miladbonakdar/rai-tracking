using System;
using Domain.Enums;
using SharedKernel;

namespace Domain.Commands
{
    public class SetOtdrValueCommandRequest : ApplicationCommand
    {
        protected SetOtdrValueCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.SetOtdrValue, Dic.CommandNames.SetOtdrValue, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}