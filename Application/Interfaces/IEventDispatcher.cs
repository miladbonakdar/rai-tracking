﻿using Domain.Interfaces;
using SharedKernel.Interfaces;

namespace Application.Interfaces
{
    public interface IEventDispatcher
    {
        void Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent;
    }
}