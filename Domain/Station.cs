using System;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Domain
{
    public class Station : AggregateRoot, IOrganizationTenant
    {
        private Station()
        {
        }

        public Station(string name, int organizationId)
        {
            Name = name;
            OrganizationId = organizationId;
        }

        public Station(int id, double latitude, double longitude, double altitude, string name, int organizationId,
            int? preStationId = null, int? postStationId = null)
            : this(name, organizationId)
        {
            Id = id;
            PreStationId = preStationId;
            PostStationId = postStationId;
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

        public void Update(string name, in int organizationId)
        {
            Name = name;
            OrganizationId = organizationId;
        }
        
        public void DetachPreStation() => PreStationId = null;
        public void DetachPostStation() => PostStationId = null;

        public Station SetPostStation(Station postStation, bool force, bool arrangeNeighbor = true)
        {
            if (postStation is null) return this;
            if (PostStationId == postStation.Id) return this;
            if (force)
            {
                PostStationId = postStation.Id;
                if (arrangeNeighbor)
                    postStation.SetPreStation(this, true, false);
                return this;
            }

            if (PostStationId != null)
                throw new ConflictedException($"ایسگاه {Name} در حال حاضر دارای ایسگاه بعدی می باشد");
            PostStationId = postStation.Id;
            if (arrangeNeighbor)
                postStation.SetPreStation(this, false, false);
            return this;
        }


        public Station SetPreStation(Station preStation, bool force, bool arrangeNeighbor = true)
        {
            if (preStation is null) return this;
            if (PreStationId == preStation.Id) return this;
            if (force)
            {
                PreStationId = preStation.Id;
                if (arrangeNeighbor)
                    preStation.SetPostStation(this, true, false);
                return this;
            }

            if (PreStationId != null)
                throw new ConflictedException($"ایسگاه {Name} در حال حاضر دارای ایسگاه قبلی می باشد");
            PreStationId = preStation.Id;
            if (arrangeNeighbor)
                preStation.SetPreStation(this, false, false);
            return this;
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