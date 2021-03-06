﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Services;
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
            builder.RegisterType<AuthService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AgentService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<DepoService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AdminService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<StationService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<MissionService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<IdentityProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}