using System;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Station : AggregateRoot, IOrganizationTenant
    {
        private Station()
        {
        }

        public Station(string name, int organizationId,
            int? preStationId = null, int? postStationId = null)
        {
            Name = name;
            PreStationId = preStationId;
            PostStationId = postStationId;
            OrganizationId = organizationId;
        }

        public Station(int id, double latitude, double longitude, double altitude, string name, int organizationId,
            int? preStationId = null, int? postStationId = null)
            : this(name, organizationId, preStationId, postStationId)
        {
            Id = id;
            Latitude = latitude;
            Altitude = altitude;
            Longitude = longitude;
        }

        public Station SetPosition(double latitude, double longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            return this;
        }
        
        public void Update(string name, in int organizationId, int? preStationId, int? postStationId)
        {
            Name = name;
            PreStationId = preStationId;
            PostStationId = postStationId;
            OrganizationId = organizationId;
        }

        [Required] [MaxLength(150)] public string Name { get; private set; }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double Altitude { get; private set; }

        public int? PreStationId { get; private set; }
        public Station PreStation { get; private set; }

        public int? PostStationId { get; private set; }
        public Station PostStation { get; private set; }

        public int OrganizationId { get; private set; }
        public Organization Organization { get; private set; }

    }
}