using System.Globalization;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Commands
{
    public class EditProjectCommandRequest : ApplicationCommand
    {
        private readonly int _missionId;
        private readonly string _description;
        private readonly int _remainingType;
        private readonly Zone _zone;

        private readonly string _template =
            "{\"c\":\"{{command}}\",\"mid\":{{missionId}},\"aid\":{{adminId}},\"des\":\"{{description}}\",\"rt\": {{remainingTime}},\"r\":{{radius}},\"p\":{\"lat\":{{latitude}},\"lon\":{{longitude}}}}";

        public EditProjectCommandRequest(string phoneNumber, int adminId, int agentId,
            int missionId, string description, int remainingType, Zone zone)
            : base(CommandType.NewMission,
                phoneNumber, adminId, agentId)
        {
            _missionId = missionId;
            _description = description;
            _remainingType = remainingType;
            _zone = zone;
        }

        protected override string GenerateMessage() =>
            _template.Replace("{{command}}", Map[CommandType])
                .Replace("{{missionId}}", _missionId.ToString())
                .Replace("{{adminId}}", AdminId.ToString())
                .Replace("{{description}}", _description)
                .Replace("{{remainingTime}}", _remainingType.ToString())
                .Replace("{{radius}}", _zone.Radius.ToString(CultureInfo.InvariantCulture))
                .Replace("{{latitude}}", _zone.Latitude.ToString(CultureInfo.InvariantCulture))
                .Replace("{{longitude}}", _zone.Longitude.ToString(CultureInfo.InvariantCulture));
    }
}