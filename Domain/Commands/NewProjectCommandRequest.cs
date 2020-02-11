using System;
using Domain.Enums;
using SharedKernel;

namespace Domain.Commands
{
    public class NewProjectCommandRequest : ApplicationCommand
    {
        protected NewProjectCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.NewMission, Dic.CommandNames.NewProject, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}