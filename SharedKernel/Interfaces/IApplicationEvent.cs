using System;
using SharedKernel.Enums;

namespace SharedKernel.Interfaces
{
    public interface IApplicationEvent
    {
        DateTime OccurredAt { get; }
        string Name { get; }
    }
}