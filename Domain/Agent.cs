﻿using System;
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

            if (LastLocation is null) LastLocation = newLocation;
            else LastLocation.UpdateFrom(newLocation);
            return this;
        }

        public Agent UpdateInfo([NotNull] AgentInfo info)
        {
            LastUpdate = DateTime.Now;

            if (AgentInfo is null) AgentInfo = info;
            else AgentInfo.UpdateFrom(info);

            return this;
        }

        public Agent UpdateSetting([NotNull] AgentSetting setting)
        {
            LastUpdate = DateTime.Now;

            if (AgentSetting is null) AgentSetting = setting;
            else AgentSetting.UpdateFrom(setting);

            return this;
        }

        public Agent Update(string email, string phoneNumber, string name, string lastname)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            PersonName.UpdateFrom(new PersonName(name, lastname));
            return this;
        }

        public Agent UpdatePassword(string newPasswordHash)
        {
            Password = newPasswordHash;
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
        public PersonName PersonName { get; private set; }
        public AgentInfo AgentInfo { get; private set; }
        public AgentSetting AgentSetting { get; private set; }
        public Location LastLocation { get; private set; }

        //navigation properties
        public int DepoId { get; private set; }
        public Depo Depo { get; private set; }

        public ICollection<Command> Commands { get; protected set; }
        public ICollection<AgentEvent> Events { get; protected set; }
        public ICollection<Mission> Missions { get; protected set; }
        public ICollection<MissionEvent> MissionEvents { get; protected set; }
    }
}