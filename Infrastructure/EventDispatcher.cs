using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.EventHandlers.TrackingEvents;
using Application.Interfaces;
using Autofac;
using Domain.Events;
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

        public async Task Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent
        {
            var handlers = GetEventHandlers<TEvent>();
            foreach (var handler in handlers) await handler.Handle(@event);
        }

        private IEnumerable<IHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IApplicationEvent
        {
            var handlers = _container.Resolve<IEnumerable<IHandler<TEvent>>>().ToList();
            if (typeof(TrackingEvent).IsAssignableFrom(typeof(TEvent)))
            {
                var globalHandler = _container.Resolve<IHandler<TrackingEvent>>();
                handlers.Add(globalHandler as IHandler<TEvent>);
            }

            return handlers;
        }
    }
}