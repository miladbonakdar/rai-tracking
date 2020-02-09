using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class MissionLocation : Entity , IMission
    {
        public Location Location { get; set; }

        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}