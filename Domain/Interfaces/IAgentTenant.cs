using System;

namespace Domain.Interfaces
{
    public interface IAgentTenant
    {
        int AgentId { set; get; }
        Agent Agent { set; get; }
    }
}