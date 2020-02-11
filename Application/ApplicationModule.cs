using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Domain.Interfaces;
using DomainEvent.Extensions;
using Module = Autofac.Module;

namespace Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(GetType()))
                .Where(t => t.IsAssignableToGenericType(typeof(IHandler<>))).AsImplementedInterfaces();
        }
    }
}
