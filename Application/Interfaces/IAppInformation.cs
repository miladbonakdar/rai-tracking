using System;

namespace Application.Interfaces
{
    public interface IAppInformation
    {
        string Version { get; }
        string VersionType { get; }
        int BuildNumber { get; }
        DateTime BuildDate { get; }
        string AppName { get; }
        string CreatedBy { get; }
    }
}