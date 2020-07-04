using Domain.ValueObjects;

namespace Application.ADO
{
    public class EditMissionCommandAdo
    {
        public int MissionId { get; set; }
        public string AgentNumber { get; set; }
        public int AgentId { get; set; }
        public int AdminId { get; set; }
        public int RemainingTime { get; set; }
        public Zone ProbableFailureZone { get;set; }
        public string Description { get; set; }
        public int StationOneId { get; set; }
        public int? StationTwoId { get; set; }
    }
}