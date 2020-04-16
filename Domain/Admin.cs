using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;


namespace Domain
{
    public class Admin : AggregateRoot, IOrganizationTenant
    {
        private Admin()
        {
        }

        public Admin([NotNull] PersonName personName, [NotNull] string adminType, int organizationId
            , string phoneNumber = null
            , string telephone = null, string about = null)
        {
            PersonName = personName;
            AdminType = adminType ?? throw new ArgumentNullException();
            OrganizationId = organizationId;
            PhoneNumber = phoneNumber;
            Telephone = telephone;
            About = about;
            Missions = new List<Mission>();
        }

        public void Register([NotNull] string email, [NotNull] string hashPassword)
        {
            Email = email ?? throw new ArgumentNullException();
            Password = hashPassword ?? throw new ArgumentNullException();
        }


        public Admin UpdateInfo(string phoneNumber, string name,
            string lastname, string about, string number)
        {
            PhoneNumber = phoneNumber;
            PersonName.UpdateFrom(new PersonName(name, lastname));
            About = about;
            Telephone = number;
            return this;
        }

        public Admin UpdateOrganization(int organId)
        {
            OrganizationId = organId;
            return this;
        }

        public Admin UpdateAdminType(string adminType)
        {
            AdminType = adminType;
            return this;
        }

        public Admin UpdateEmail(string email)
        {
            Email = email;
            return this;
        }

        public void UpdatePassword(string hashPassword) => Password = hashPassword ?? throw new ArgumentNullException();

        public PersonName PersonName { get; private set; }
        [Required] public string Email { get; private set; }
        [Required] public string Password { get; private set; }
        [MaxLength(13)] public string PhoneNumber { get; private set; }
        [MaxLength(13)] public string Telephone { get; private set; }
        public string About { get; set; }

        private string _adminType;

        [Required]
        public string AdminType
        {
            get => _adminType;
            private set
            {
                Guard.ForValidRoleName(value);
                _adminType = value;
            }
        }

        [Required] public int OrganizationId { get; private set; }
        public Organization Organization { get; private set; }

        public ICollection<Mission> Missions { get; set; }
    }
}