using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTO
{
    public class UpdateMissionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "زمان تخمینی انجام کار را وارد کنید"),
         Range(1, 1000, ErrorMessage = "زمان تخمینی باید بزرگتر از 0 باشد")]
        public int RemainingTime { get; set; }

        [Required(ErrorMessage = "توضیحات را وارد کنید"), MinLength(10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "ایستگاه اول را وارد کنید")]
        public int StationOneId { get; set; }

        public int? StationTwoId { get; set; }

        [Required(ErrorMessage = "نقطه ی تقریبی خرابی را انتخاب کنید")]
        public ZoneDto Zone { get; set; }

        public MissionDto ToMissionDto(int id, int agentId, MissionPhase phase) =>
            new MissionDto
            {
                Description = this.Description,
                Id = id,
                Phase = phase,
                AgentId = agentId,
                RemainingTime = RemainingTime,
                StationOneId = StationOneId,
                StationTwoId = StationOneId,
                Zone = Zone
            };
    }
}