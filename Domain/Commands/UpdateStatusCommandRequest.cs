using System;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class UpdateStatusCommandRequest : ApplicationCommand
    {
        protected UpdateStatusCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.UpdateStatus, Dic.CommandNames.UpdateStatus, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}