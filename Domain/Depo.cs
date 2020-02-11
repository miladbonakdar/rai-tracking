using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Depo : AggregateRoot, IOrganizationTenant
    {
        public Location Location { get; set; }
        [Required]
        public string Name { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}