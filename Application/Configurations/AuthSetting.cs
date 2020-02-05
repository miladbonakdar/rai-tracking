using Application.Interfaces;

namespace Application.Configurations
{
    public class AuthSetting : IAuthSetting
    {
        public string Secret { get; set; }
        public int UserExpireInDays { get; set; }
        public int AgentExpireInDays { get; set; }
    }
}
