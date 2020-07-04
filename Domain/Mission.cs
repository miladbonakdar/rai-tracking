using System;
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
            Zone zone, string description, int? stationTwoId = null)
        {
            AgentId = agentId;
            RemainingTime = remainingTime;
            StationOneId = stationOneId;
            StationTwoId = stationTwoId;
            Description = description;
            Phase = MissionPhase.NotStarted;
            Locations = new List<MissionLocation>();
            Events = new List<MissionEvent>();
            ProbableFailureZone = zone;
        }

        public void Start()
            => (Phase, StartedAt) = (MissionPhase.Started, DateTime.Now);

        public void Finish()
            => (Phase, FinishedAt) = (MissionPhase.Finished, DateTime.Now);

        public void Cancel()
            => (Phase, FinishedAt) = (MissionPhase.Canceled, DateTime.Now);

        public void UpdateOtdr(int otdr) => OTDR = otdr;

        public void UpdateFailureLocation(Location location)
        {
            if (FailureLocation is null) FailureLocation = location;
            else FailureLocation.UpdateFrom(location);
        }
        
        public void UpdateFailureZone(Zone zone)
        {
            if (ProbableFailureZone is null) ProbableFailureZone = zone;
            else ProbableFailureZone.UpdateFrom(zone);
        }

        public void UpdateMission(int remainingTime, int stationOneId,Zone zone,
            int? stationTwoId = null, string description = null)
        {
            RemainingTime = remainingTime;
            StationOneId = stationOneId;
            StationTwoId = stationTwoId;
            Description = description;
            UpdateFailureZone(zone);
        }

        public int RemainingTime { get; private set; }
        public int? OTDR { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public MissionPhase Phase { get; private set; }
        public Location FailureLocation { get; private set; }
        public Zone ProbableFailureZone { get; private set; }
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