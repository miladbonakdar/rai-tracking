using System;
using System.Collections.Generic;
using Autofac;

namespace SharedKernel.Interfaces
{
    public interface IDomainEvents
    {
        void Register<T>(Action<T> callback) where T : IDomainEvent;
        void ClearCallbacks();
        void Raise<T>(T args) where T : IDomainEvent;
    }
}
