using System;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Station : AggregateRoot, IOrganizationTenant
    {
        [Required]
        public int Code { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public Location Location { get; set; }

        public int? PreStationId { get; set; }
        public Station PreStation { get; set; }
        
        public int? PostStationId { get; set; }
        public Station PostStation { get; set; }
        
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}