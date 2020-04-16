using System;
using System.Threading.Tasks;
using Domain.Events;
using Domain.Interfaces;

namespace Application.EventHandlers.TrackingEvents
{
    public class NewMissionStartedHandler : IHandler<NewMissionStarted>
    {
        public Task Handle(NewMissionStarted @event)
        {
            Console.WriteLine("NewMissionStarted");
            return Task.CompletedTask;
        }
    }
}