using Domain.Enums;

namespace Domain.Commands
{
    public class CancelProjectCommandRequest : ApplicationCommand
    {
        private readonly int _missionId;

        private readonly string _template = 
            "{\"c\":\"{{command}}\",\"mid\":{{missionId}},\"aid\":{{adminId}}}";
        public CancelProjectCommandRequest(string phoneNumber, int adminId, int agentId,int missionId)
            : base(CommandType.CancelMission, 
                phoneNumber, adminId, agentId)
        {
            _missionId = missionId;
        }


        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{missionId}}", _missionId.ToString())
                .Replace("{{adminId}}", AdminId.ToString());
    }
}