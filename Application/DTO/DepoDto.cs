using System;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.DTO
{
    public class DepoDto
    {
        public int Id { get; set; }
        public LocationDto Location { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int OrganizationId { get; set; }
        [Required] public int StationId { get; set; }

        private static readonly Func<Depo, DepoDto> DefaultConverter =
            depo => new DepoDto()
            {
                Location = LocationDto.FromDomain(depo.Location),
                Name = depo.Name,
                Id = depo.Id,
                OrganizationId = depo.OrganizationId,
                StationId = depo.StationId
            };

        public static DepoDto FromDomain(Depo depo
            , Func<Depo, DepoDto> converter = null)
        {
            if (converter is null)
                converter = DefaultConverter;
            return converter(depo);
        }
    }
}