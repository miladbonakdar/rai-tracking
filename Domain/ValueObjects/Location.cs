using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using SharedKernel;

namespace Domain.ValueObjects
{
    public class Location : ValueObject<Location>
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Location(double latitude, double longitude, DateTime date)
        {
            Guard.ValidateCoordinate(latitude, longitude,
                "latitude", "longitude");
            Latitude = latitude;
            Longitude = longitude;
            CreatedAt = date;
        }
        public Location(double latitude, double longitude)
            : this(latitude, longitude, DateTime.Now) { }

        protected Location() { }

        public Location NewLongitude(double longitude)
        {
            return new Location(Latitude, longitude, CreatedAt);
        }

        public Location NewLatitude(double latitude)
        {
            return new Location(latitude, Longitude, CreatedAt);
        }

        public override bool IsEmpty() =>
            default(double) == Latitude &&
            default(double) == Longitude &&
            default(DateTime) == CreatedAt;

        public static Location CreateEmpty() =>
            new Location();
    }

    public abstract class CommandRequest : ICommandRequest
    {
        protected CommandRequest(CommandType commandType, string name)
        {
            CreatedAt = DateTime.Now;
            CommandType = commandType;
            Name = name;
        }

        public DateTime CreatedAt { get; }
        public string Name { get; }
        public CommandType CommandType { get; }
        public DateTime? SentAt { get; private set; }
        public bool IsSent => SentAt != null;
        public ICommandRequest Send()
        {
            SentAt = DateTime.Now;
            return this;
        }

    }

    public interface ICommandRequest
    {
        DateTime CreatedAt { get; }
        DateTime? SentAt { get; }
        bool IsSent { get; }
        ICommandRequest Send();
    }

    public class UpdateStatusCommandRequest : CommandRequest
    {
        protected UpdateStatusCommandRequest()
            : base(CommandType.UpdateStatus, Dic.CommandNames.UpdateStatus)
        {

        }
    }
    public class SetOtdrValueCommandRequest : CommandRequest
    {
        protected SetOtdrValueCommandRequest()
            : base(CommandType.SetOtdrValue, Dic.CommandNames.SetOtdrValue)
        {

        }
    }
    public class NewProjectCommandRequest : CommandRequest
    {
        protected NewProjectCommandRequest()
            : base(CommandType.NewProject, Dic.CommandNames.NewProject)
        {

        }
    }

    public class EditProjectCommandRequest : CommandRequest
    {
        protected EditProjectCommandRequest() 
            : base(CommandType.EditProject, Dic.CommandNames.EditProject)
        {

        }
    }
    public class FinishProjectCommandRequest : CommandRequest
    {
        protected FinishProjectCommandRequest() 
            : base(CommandType.FinishProject, Dic.CommandNames.FinishProject)
        {

        }
    }
    public class CancelProjectCommandRequest : CommandRequest
    {
        protected CancelProjectCommandRequest() 
            : base(CommandType.CancelProject, Dic.CommandNames.CancelProject)
        {

        }
    }
    public class SetSettingCommandRequest : CommandRequest
    {
        protected SetSettingCommandRequest() 
            : base(CommandType.SetSetting, Dic.CommandNames.SetSetting)
        {

        }
    }
}
