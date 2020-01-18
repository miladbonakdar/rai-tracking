using System;

namespace Domain.Interfaces
{
    public interface IAgentTenant
    {
        Guid AgentId { set; get; }
        Agent Agent { set; get; }
    }
}