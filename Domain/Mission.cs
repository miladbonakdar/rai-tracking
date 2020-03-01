﻿using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public class Mission : AggregateRoot, IAgentTenant
    {
        private Mission()
        {
            
        }
        public Mission(int agentId, int remainingTime, int stationOneId,
            int? stationTwoId = null, string description = null)
        {
            AgentId = agentId;
            RemainingTime = remainingTime;
            StationOneId = stationOneId;
            StationTwoId = stationTwoId;
            Description = description;
            Phase = ProjectPhase.Unknown;
            Locations = new List<MissionLocation>();
            Events = new List<MissionEvent>();
        }

        public void Start()
            => (Phase, StartedAt) = (ProjectPhase.Started, DateTime.Now);

        public void Finish()
            => (Phase, FinishedAt) = (ProjectPhase.Finished, DateTime.Now);

        public void Cancel()
            => (Phase, FinishedAt) = (ProjectPhase.Canceled, DateTime.Now);

        public void UpdateOtdr(int otdr) => OTDR = otdr;
        public void UpdateFailureLocation(Location location)
            => FailureLocation = location;

        public void UpdateMission(int remainingTime, int stationOneId,
            int? stationTwoId = null, string description = null)
        {
            RemainingTime = remainingTime;
            StationOneId = stationOneId;
            StationTwoId = stationTwoId;
            Description = description;
        }

        public int RemainingTime { get; private set; }
        public int? OTDR { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectPhase Phase { get; private set; }
        public Location FailureLocation { get; private set; }
        public string Description { get; private set; }

        public int StationOneId { get; private set; }
        public Station StationOne { get; private set; }

        public int? StationTwoId { get; private set; }
        public Station StationTwo { get; private set; }

        public int AgentId { get; private set; }
        public Agent Agent { get; set; }

        public ICollection<MissionLocation> Locations { set; get; }
        public ICollection<MissionEvent> Events { set; get; }
    }
}