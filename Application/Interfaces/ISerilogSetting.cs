namespace Application.Interfaces
{
    public interface ISerilogSetting
    {
        string LogFileName { get; }
        string Path { get; }
        int RollingInterval { get; }
    }
}   