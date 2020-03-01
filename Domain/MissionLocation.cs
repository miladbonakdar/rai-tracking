using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public class MissionLocation : Entity, IMission
    {
        private MissionLocation()
        {
            
        }
        public MissionLocation([NotNull] Location location, int missionId)
        {
            MissionId = missionId;
            Location = location;
        }

        public Location Location { get; private set; }

        public int MissionId { get; private set; }
        public Mission Mission { get; set; }
    }
}