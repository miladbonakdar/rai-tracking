using System;
using SharedKernel;

namespace Domain.ValueObjects
{
    public class AgentInfo : ValueObject<AgentInfo>
    {

        public bool IsGpsOn { get; protected set; }
        public int Battery { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public AgentInfo(int battery, bool isGpsOn)
        {
            Battery = battery;
            IsGpsOn = isGpsOn;
            UpdatedAt = DateTime.Now;
        }

        public override bool IsEmpty()
        {
            return false;
        }

    }
}