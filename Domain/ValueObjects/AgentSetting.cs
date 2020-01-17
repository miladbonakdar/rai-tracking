using SharedKernel;

namespace Domain.ValueObjects
{
    public class AgentSetting : ValueObject<AgentSetting>
    {

        private static readonly AgentSetting DefaultSetting = new AgentSetting{
            Version = 1
        };

        public int Version { get; protected set; }

        public AgentSetting()
        {
        }

        public override bool IsEmpty()
        {
            return Version == default(int);
        }
        public static AgentSetting CreateEmpty() =>
            new AgentSetting();

        public static AgentSetting CreateDefault() =>
            DefaultSetting.MemberwiseClone() as AgentSetting;
    }
}