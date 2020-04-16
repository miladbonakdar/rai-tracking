using System.Threading.Tasks;
using Domain.Interfaces;
using SharedKernel.Interfaces;

namespace Application.Interfaces
{
    public interface IEventDispatcher
    {
        Task Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent;
    }
}