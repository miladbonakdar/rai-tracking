namespace SharedKernel.Interfaces
{
    public interface IAppSetting
    {
        string DashboardBaseUrl { get; }
        string ApiBaseUrl { get; }
        bool DevelopmentMode { get; }
        string AdminEmailAddress { get; }
        string RootPassword { get; }
    }
}