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

        public Location(double latitude, double longitude, DateTime date)
        {
            Guard.ValidateCoordinate(latitude, longitude,
                "latitude", "longitude");
            Latitude = latitude;
            Longitude = longitude;
        }

        public Location(double latitude, double longitude)
            : this(latitude, longitude, DateTime.Now)
        {
        }

        protected Location()
        {
        }

        public Location NewLongitude(double longitude)
        {
            return new Location(Latitude, longitude);
        }

        public Location NewLatitude(double latitude)
        {
            return new Location(latitude, Longitude);
        }

        public override bool IsEmpty() =>
            default(double) == Latitude &&
            default(double) == Longitude;

        public static Location CreateEmpty() =>
            new Location();
    }
}