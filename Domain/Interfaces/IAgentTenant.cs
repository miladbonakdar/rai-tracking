using System;

namespace Domain.Interfaces
{
    public interface IAgentTenant
    {
        int AgentId { get; }
        Agent Agent { get; }
    }
}