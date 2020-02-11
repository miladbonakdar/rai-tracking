using System;
using Domain.Enums;
using SharedKernel;

namespace Domain.Commands
{
    public class EditProjectCommandRequest : ApplicationCommand
    {
        protected EditProjectCommandRequest(string phoneNumber, string createdBy, int? adminId, int agentId)
            : base(CommandType.EditMission, Dic.CommandNames.EditProject, 
                phoneNumber, createdBy, adminId, agentId)
        {
        }

        protected override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}