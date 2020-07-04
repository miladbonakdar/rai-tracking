using System;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IApplicationCommand
    {
        CommandType CommandType { get; }
        string PhoneNumber { get; }
        int AdminId { get; }
        int AgentId { get; }
        string Message { get; }
    }
}