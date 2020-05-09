using SharedKernel.Interfaces;

namespace Application.Configurations
{
    public class AuthSetting : IAuthSetting
    {
        public string Secret { get; set; }
        public int AdminExpireInDays { get; set; }
        public int AgentExpireInDays { get; set; }
    }
}
