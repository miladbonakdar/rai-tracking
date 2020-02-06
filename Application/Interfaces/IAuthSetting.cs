namespace Application.Interfaces
{
    public interface IAuthSetting
    {
        string Secret { get; }
        int UserExpireInDays { get; }
        int AgentExpireInDays { get; }
    }
}