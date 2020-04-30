using SharedKernel;

namespace Domain.ValueObjects
{
    public class Zone : ValueObject<Zone>
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public double Radius { get; protected set; }

        public Zone(double latitude, double longitude, double radius)
        {
            Guard.ValidateRadius(radius,
                "radius");

            Guard.ValidateCoordinate(latitude, longitude,
                "latitude", "longitude");
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        private Zone()
        {
        }

        public override void UpdateFrom(Zone zone)
        {
            Longitude = zone.Longitude;
            Latitude = zone.Latitude;
            Radius = zone.Radius;
        }

        public override bool IsEmpty() =>
            default == Latitude &&
            default == Longitude &&
            default == Radius;
    }
}