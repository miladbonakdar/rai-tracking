using System;
using Domain.Interfaces;
using SharedKernel;

namespace Domain
{
    public class MissionEvent : Event, IMission
    {
        public Guid MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}