using System.Collections.Generic;
using Application.Interfaces;
using Autofac;
using Domain.Interfaces;
using SharedKernel.Interfaces;

namespace Infrastructure
{
    class EventDispatcher : IEventDispatcher
    {
        private readonly ILifetimeScope _container;

        public EventDispatcher(ILifetimeScope container)
        {
            _container = container;
        }

        public void Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent
        {
            var handlers = _container.Resolve<IEnumerable<IHandler<TEvent>>>();
            foreach (var handler in handlers) handler.Handle(@event);
        }
    }
}