using System;
using Domain.ValueObjects;

namespace Application.DTO
{
    public class LocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        private static readonly Func<Location, LocationDto> DefaultConverter =
            location => new LocationDto()
            {
                Latitude = location?.Latitude ?? 0,
                Longitude = location?.Longitude ?? 0,
            };

        public static LocationDto FromDomain(Location location
            , Func<Location, LocationDto> converter = null)
        {
            if (converter is null)
                converter = DefaultConverter;
            return converter(location);
        }
    }
}