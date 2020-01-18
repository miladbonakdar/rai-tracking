using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Agent : AggregateRoot
    {

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }
        public Location LastLocation { get; set; }
        public PersonName PersonName { get; set; }
        public AgentInfo AgentInfo { get; set; }
        public AgentSetting AgentSetting { get; set; }

        //navigation properties
        public Guid DepoId { get; set; }
        public virtual Depo Depo { get; set; }
    }
}