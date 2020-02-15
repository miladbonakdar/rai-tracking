using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Admin : AggregateRoot, IOrganizationTenant
    {
        public PersonName PersonName { get; set; }        
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [MaxLength(13)] public string PhoneNumber { get; set; }
        [MaxLength(13)] public string Telephone { get; set; }
        public string About { get; set; }

        private string _adminType;

        public string AdminType
        {
            get => _adminType;
            set
            {
                Guard.ForValidRoleName(value);
                _adminType = value;
            }
        }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public ICollection<Mission> Missions { get; set; }
    }
}