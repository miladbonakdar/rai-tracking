namespace Application.Interfaces
{
    public interface IAuthSetting
    {
        string Secret { get; }
        int AdminExpireInDays { get; }
        int AgentExpireInDays { get; }
    }
}