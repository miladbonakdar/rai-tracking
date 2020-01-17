using SharedKernel.Enums;

namespace SharedKernel.Interfaces
{
    public interface IApplicationEvent : IDomainEvent
    {
        ApplicationEventType ApplicationEventType { get; }
    }
}