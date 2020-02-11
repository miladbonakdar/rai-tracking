using System;
using Domain.Enums;
using SharedKernel;

namespace Domain.Commands
{
    public class FinishProjectCommandRequest : ApplicationCommand
    {
        protected FinishProjectCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.FinishMission, Dic.CommandNames.FinishProject, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}