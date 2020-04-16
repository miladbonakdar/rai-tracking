using System;
using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;

namespace Application.DTO
{
    public class LocationUpdateDto
    {
        [Required]
        public double Latitude { get; set; }
        
        [Required]
        public double Longitude { get; set; }

        [Required]
        public int DomainId { get; set; }
        
        public LocationUpdateDto()
        {
        }

        private LocationUpdateDto(LocationDto locationDto, int domainId)
        {
            Latitude = locationDto.Latitude;
            Longitude = locationDto.Longitude;
            DomainId = domainId;
        }
        
        private static readonly Func<Location, LocationDto> DefaultConverter =
            location => new LocationDto()
            {
                Latitude = location?.Latitude ?? 0,
                Longitude = location?.Longitude ?? 0,
            };

        public static LocationUpdateDto FromDomain(int domainId, Location location
            , Func<Location, LocationDto> converter = null)
        {
            if (converter is null)
                converter = DefaultConverter;
            var item = converter(location);
            return new LocationUpdateDto(item, domainId);
        }
    }
}