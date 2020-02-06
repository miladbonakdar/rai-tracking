using System;
using Application.Interfaces;

namespace Application.Configurations
{
    public class AppInformation : IAppInformation
    {
        public string Version { get; set; }
        public string VersionType { get; set; }
        public int BuildNumber { get; set; }
        public DateTime BuildDate { get; set; }
        public string AppName { get; set; }
        public string CreatedBy { get; set; }
    }
}