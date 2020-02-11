using SharedKernel.Interfaces;

namespace Domain.Interfaces
{
    public interface IHandler<in TEvent> where TEvent : IApplicationEvent
    {
        public void Handle(TEvent @event);
    }
}