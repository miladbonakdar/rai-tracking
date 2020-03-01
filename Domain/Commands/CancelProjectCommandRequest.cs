using System;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class CancelProjectCommandRequest : ApplicationCommand
    {
        protected CancelProjectCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.CancelMission, Dic.CommandNames.CancelProject, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}