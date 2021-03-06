﻿using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTO
{
    public class MissionDto
    {
        public int Id { get; set; }
        public int RemainingTime { get; set; }
        public MissionPhase Phase { get; set; }
        public string Description { get; set; }
        public int StationOneId { get; set; }
        public int? StationTwoId { get; set; }
        public int AgentId { get; set; }
    }
}