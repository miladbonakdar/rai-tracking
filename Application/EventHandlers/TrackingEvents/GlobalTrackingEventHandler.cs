using System;
using System.Threading.Tasks;
using Domain.Events;
using Domain.Interfaces;

namespace Application.EventHandlers.TrackingEvents
{
    public class GlobalTrackingEventHandler : IHandler<TrackingEvent>
    {
        public GlobalTrackingEventHandler()
        {
            
        }
        
        public Task Handle(TrackingEvent @event)
        {
            Console.WriteLine("TrackingEvent");
            return Task.CompletedTask;
        }
    }
}