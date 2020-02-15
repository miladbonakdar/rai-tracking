using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Agent : AggregateRoot
    {
        [Required] [MaxLength(13)] public string PhoneNumber { get; private set; }

        [Required] public string Password { get; set; }
        public string Email { get; private set; }
        public DateTime LastUpdate { get; set; }
        public Location LastLocation { get; private set; }
        public PersonName PersonName { get; private set; }
        public AgentInfo AgentInfo { get; private set; }
        public AgentSetting AgentSetting { get; private set; }

        //navigation properties
        public int DepoId { get; private set; }
        public Depo Depo { get; protected set; }

        public ICollection<Command> Commands { get; protected set; }
        public ICollection<AgentEvent> Events { get; protected set; }
        public ICollection<Mission> Missions { get; protected set; }
        public ICollection<MissionEvent> MissionEvents { get; protected set; }
    }
}