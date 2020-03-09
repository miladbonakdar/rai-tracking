using System;
using Domain;

namespace Application.DTO
{
    public class OrganizationDto : IModelDto
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public LocationDto Location { get; set; }
        public string Code { get; set; }

        private static readonly Func<Organization,OrganizationDto> DefaultConverter =
         organization => new OrganizationDto
         {
             Code = organization.Code,
             Id = organization.Id,
             Location = LocationDto.FromDomain(organization.Location),
             Name = organization.Name,
             IsAdmin = organization.IsAdmin
         }; 
        
        public static OrganizationDto FromDomain(Organization organization
            ,Func<Organization,OrganizationDto> converter = null)
        {
            if (organization is null) throw new ArgumentNullException(nameof(organization));
            
            if (converter is null)
                converter = DefaultConverter;
            return converter(organization);
        }
    }
}