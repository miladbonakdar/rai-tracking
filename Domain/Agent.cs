using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using SharedKernel;

namespace Domain
{
    public class Agent : AggregateRoot
    {
        public Agent([NotNull] PersonName personName, [NotNull] string phoneNumber
            , [NotNull] AgentSetting setting
            , int depoId)
        {
            DepoId = depoId;
            PersonName = personName ?? throw new ArgumentNullException();
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException();
            AgentSetting = setting ?? throw new ArgumentNullException();
            Missions = new List<Mission>();
            Events = new List<AgentEvent>();
            MissionEvents = new List<MissionEvent>();
            Commands = new List<Command>();
        }

        private Agent()
        {
        }

        public Agent UpdateLocation([NotNull] Location newLocation)
        {
            LastUpdate = DateTime.Now;
            LastLocation = newLocation;
            return this;
        }

        public Agent UpdateLocation([NotNull] AgentInfo info)
        {
            LastUpdate = DateTime.Now;
            AgentInfo = info;
            return this;
        }

        public void Register([NotNull] string email, [NotNull] string hashPassword)
        {
            Email = email ?? throw new ArgumentNullException();
            Password = hashPassword ?? throw new ArgumentNullException();
        }

        [Required] [MaxLength(13)] public string PhoneNumber { get; private set; }

        [Required] public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public Location LastLocation { get; private set; }
        public PersonName PersonName { get; private set; }
        public AgentInfo AgentInfo { get; private set; }
        public AgentSetting AgentSetting { get; private set; }

        //navigation properties
        public int DepoId { get; private set; }
        public Depo Depo { get; private set; }

        public ICollection<Command> Commands { get; protected set; }
        public ICollection<AgentEvent> Events { get; protected set; }
        public ICollection<Mission> Missions { get; protected set; }
        public ICollection<MissionEvent> MissionEvents { get; protected set; }
    }
}