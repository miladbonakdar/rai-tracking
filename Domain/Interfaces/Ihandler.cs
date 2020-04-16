using System.Threading.Tasks;
using SharedKernel.Interfaces;

namespace Domain.Interfaces
{
    public interface IHandler<in TEvent> where TEvent : IApplicationEvent
    {
        public Task Handle(TEvent @event);
    }
}