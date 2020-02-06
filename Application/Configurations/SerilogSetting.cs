using Application.Interfaces;

namespace Application.Configurations
{
    public class SerilogSetting : ISerilogSetting
    {
        public string LogFileName { get; set; }
        public string Path { get; set; }
        public int RollingInterval { get; set; }
    }
}
