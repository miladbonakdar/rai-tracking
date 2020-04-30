namespace Application.DTO
{
    public class UpdateMissionDto
    {
        public int Id { get; set; }
        public int RemainingTime { get; set; }
        public string Description { get; set; }
        public int StationOneId { get; set; }
        public int? StationTwoId { get; set; }
    }
}