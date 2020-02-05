using Application.Interfaces;

namespace Application.Configurations
{
    public class AppSetting : IAppSetting
    {
        public string DashboardBaseUrl { get; set; }
        public string ApiBaseUrl { get; set; }
        public bool DevelopmentMode { get; set; }
        public string AdminEmailAddress { get; set; }
    }
}
