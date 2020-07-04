using System;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class UpdateStatusCommandRequest : ApplicationCommand
    {
        private readonly string _template = 
            "{\"c\":\"{{command}}\",\"aid\":{{adminId}}}";
        public UpdateStatusCommandRequest(string phoneNumber,int adminId, int agentId)
            : base(CommandType.UpdateStatus, 
                phoneNumber, adminId, agentId)
        {
        }

        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{adminId}}", AdminId.ToString());
    }
}