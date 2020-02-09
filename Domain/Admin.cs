using System;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Admin : AggregateRoot , IOrganizationTenant
    {
        public PersonName PersonName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Telephone { get; set; }
        public string About { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}