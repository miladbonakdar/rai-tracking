using SharedKernel;

namespace Domain.ValueObjects
{
    public class AgentSetting : ValueObject<AgentSetting>
    {
        private static readonly AgentSetting DefaultSetting = new AgentSetting(1);

        public int Version { get; protected set; }

        public AgentSetting(int version)
        {
            Version = version;
        }

        public override void UpdateFrom(AgentSetting item)
        {
            Version = item.Version;
        }

        public override bool IsEmpty()
        {
            return Version == default(int);
        }

        public static AgentSetting CreateDefault() =>
            DefaultSetting.MemberwiseClone() as AgentSetting;
    }
}