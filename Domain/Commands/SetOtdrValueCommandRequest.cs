using System;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class SetOtdrValueCommandRequest : ApplicationCommand
    {
        private readonly int _missionId;
        private readonly int _otdr;

        private readonly string _template = 
            "{\"c\":\"{{command}}\",\"mid\":{{missionId}},\"aid\":{{adminId}}},\"otdr\":{{otdr}}}";
        public SetOtdrValueCommandRequest(string phoneNumber, int adminId, int agentId, int missionId, int otdr)
            : base(CommandType.SetOtdrValue, 
                phoneNumber, adminId, agentId)
        {
            _missionId = missionId;
            _otdr = otdr;
        }

        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{missionId}}", _missionId.ToString())
                .Replace("{{otdr}}", _otdr.ToString())
                .Replace("{{adminId}}", AdminId.ToString());
    }
}