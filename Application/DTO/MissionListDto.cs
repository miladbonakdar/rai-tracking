using System;
using Domain.Enums;

namespace Application.DTO
{
    public class MissionListDto
    {
        public int Id { get; set; }
        public int RemainingTime { get; set; }
        public MissionPhase Phase { get; set; }
        public string Description { get; set; }
        public string StationOne { get; set; }
        public string StationTwo { get; set; }
        public string Agent { get; set; }
        public string Admin { get; set; }
        public int? OTDR { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}