using System;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IApplicationCommand
    {
        CommandType CommandType { get; }
        DateTime CreatedAt { get; }
        string PhoneNumber { get; }
        string CreatedBy { get; }
        int? AdminId { get; }
        int AgentId { get; }
        string Name { get; }
        string Message { get; }
    }
}