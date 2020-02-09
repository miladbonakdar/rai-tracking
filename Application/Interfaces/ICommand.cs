using System;

namespace Application.Interfaces
{
    public interface ICommand
    {
        DateTime CreatedAt { get; }
        DateTime PhoneNumber { get; }
        string CreatedBy { get; }
        int? AdminId { get; }
        int AgentId { get; }
        string Message { get; }
    }
}