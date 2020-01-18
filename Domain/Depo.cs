using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Depo : AggregateRoot, IOrganizationTenant
    {
        public Location Location { get; set; }
        public string Name { get; set; }

        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public Guid StationId { get; set; }
        public virtual Station Station { get; set; }
    }
}