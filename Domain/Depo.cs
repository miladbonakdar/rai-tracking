using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public class Depo : AggregateRoot, IOrganizationTenant
    {
        public Depo([NotNull] string name, int organizationId, int stationId)
        {
            Name = name;
            OrganizationId = organizationId;
            StationId = stationId;
            Agents = new List<Agent>();
        }

        private Depo()
        {
        }

        public void UpdateLocation([NotNull] Location location)
            => Location.UpdateFrom(location);

        public Location Location { get; private set; }
        [Required] public string Name { get; private set; }

        public int OrganizationId { get; private set; }
        public Organization Organization { get; private set; }
        public int StationId { get; private set; }
        public Station Station { get; private set; }
        public ICollection<Agent> Agents { get; set; }

        public void Update([NotNull] string name, int organizationId, int stationId)
        {
            Name = name;
            OrganizationId = organizationId;
            StationId = stationId;
        }
    }
}