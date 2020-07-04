﻿using System;
using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTO
{
    public class MissionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage="زمان تخمینی انجام کار را وارد کنید"),
         Range(1,1000,ErrorMessage = "زمان تخمینی باید بزرگتر از 0 باشد")]
        public int RemainingTime { get; set; }
        public MissionPhase Phase { get; set; }
        public string Description { get; set; }
        public int StationOneId { get; set; }
        public int? StationTwoId { get; set; }
        public int AgentId { get; set; }
        public ZoneDto Zone { get; set; } 
        
        private static readonly Func<Mission, MissionDto> DefaultConverter =
            mission => new MissionDto()
            {
                Description = mission.Description,
                Id = mission.Id,
                Phase = mission.Phase,
                Zone = ZoneDto.FromDomain(mission.ProbableFailureZone),
                AgentId = mission.AgentId,
                RemainingTime = mission.RemainingTime,
                StationOneId = mission.StationOneId,
                StationTwoId = mission.StationTwoId
            };

        public static MissionDto FromDomain(Mission mission
            , Func<Mission, MissionDto> converter = null)
        {
            converter ??= DefaultConverter;
            return converter(mission);
        }
    }
}