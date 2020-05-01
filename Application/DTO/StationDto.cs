using System;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.DTO
{
    public class StationDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        [Required]
        public string Name { get; set; }

        public int? PreStationId { get; set; }
        public int? PostStationId { get; set; }
        [Required]
        public int OrganizationId { get; set; }

        public bool ForceUpdateNeighbors { get; set; } = false;


        private static readonly Func<Station, StationDto> DefaultConverter =
            item => new StationDto()
            {
                Altitude = item.Altitude,
                Name = item.Name,
                Id = item.Id,
                OrganizationId = item.OrganizationId,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                PostStationId = item.PostStationId,
                PreStationId = item.PreStationId
            };

        public static StationDto FromDomain(Station item
            , Func<Station, StationDto> converter = null)
        {
            if (converter is null)
                converter = DefaultConverter;
            return converter(item);
        }
    }
}