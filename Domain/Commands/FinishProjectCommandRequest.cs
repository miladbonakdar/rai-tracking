using System;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Constants;

namespace Domain.Commands
{
    public class FinishProjectCommandRequest : ApplicationCommand
    {
        private readonly int _missionId;

        private readonly string _template = 
            "{\"c\":\"{{command}}\",\"mid\":{{missionId}},\"aid\":{{adminId}}}";
        public FinishProjectCommandRequest(string phoneNumber, int adminId, int agentId, int missionId)
            : base(CommandType.FinishMission,
                phoneNumber,adminId, agentId)
        {
            _missionId = missionId;
        }

        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{missionId}}", _missionId.ToString())
                .Replace("{{adminId}}", AdminId.ToString());
    }
}