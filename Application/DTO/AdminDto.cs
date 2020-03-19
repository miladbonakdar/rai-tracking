using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;
using SharedKernel.Constants;

namespace Application.DTO
{
    public class AdminDto : PersonDto
    {
        [MinLength(8)] [Required] public string Password { get; set; }

        [Required]
        [RegularExpression(Constants.EmailRegex)]
        public string Email { get; set; }

        [MaxLength(13)] public string PhoneNumber { get; set; }
        [MaxLength(13)] public string Number { get; set; }
        [MaxLength(300)] public string About { get; set; }
        [Required] public int OrganizationId { get; set; }
        [Required] public string AdminType { get; set; }

        private static readonly Func<Admin, AdminDto> DefaultConverter = a => new AdminDto
        {
            Email = a.Email,
            Number = a.Telephone,
            Name = a.PersonName.Firstname,
            Lastname = a.PersonName.Lastname,
            PhoneNumber = a.PhoneNumber,
            Id = a.Id,
            OrganizationId = a.OrganizationId,
            About = a.About,
            AdminType = a.AdminType
        };

        public static AdminDto FromDomain(Admin admin, Func<Admin, AdminDto> converter = null)
        {
            if (converter is null)
                converter = DefaultConverter;
            var item = converter(admin);
            return item;
        }
    }
}