using System;

namespace Domain.Interfaces
{
    public interface IApplicationEvent
    {
        DateTime OccurredAt { get; }
        string Name { get; }
    }
}