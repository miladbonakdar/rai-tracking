using System;
using Domain.Interfaces;
using SharedKernel;

namespace Domain
{
    public class MissionEvent : Event, IMission
    {
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}