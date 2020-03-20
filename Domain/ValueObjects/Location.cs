using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain.Enums;
using SharedKernel;

namespace Domain.ValueObjects
{
    public class Location : ValueObject<Location>
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public Location(double latitude, double longitude)
        {
            Guard.ValidateCoordinate(latitude, longitude,
                "latitude", "longitude");
            Latitude = latitude;
            Longitude = longitude;
        }

        protected Location()
        {
        }

        public override void UpdateFrom(Location location)
        {
            Longitude = location.Longitude;
            Latitude = location.Latitude;
        }

        public override bool IsEmpty() =>
            default(double) == Latitude &&
            default(double) == Longitude;

        public static Location CreateEmpty() =>
            new Location();
    }
}