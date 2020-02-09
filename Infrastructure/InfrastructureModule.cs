using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Interfaces;
using Autofac;
using DomainEvent.Extensions;
using SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(GetType()))
                .Where(t => t.IsAssignableToGenericType(typeof(IHandler<>))).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
