using System;
using Domain.ValueObjects;

namespace Application.DTO
{
    public class ZoneDto
    {
        public double Latitude { get; set; }
        public double Longitude { get;  set; }
        public double Radius { get;  set; }
        
        private static readonly Func<Zone, ZoneDto> DefaultConverter =
            zone => new ZoneDto()
            {
                Latitude = zone?.Latitude ?? 0,
                Longitude = zone?.Longitude ?? 0,
                Radius = zone?.Radius ?? 0,
            };

        public static ZoneDto FromDomain(Zone zone
            , Func<Zone, ZoneDto> converter = null)
        {
            converter ??= DefaultConverter;
            return converter(zone);
        }
        
        public Zone ToDomain() => new Zone(Latitude,Longitude,Longitude);
    }
}