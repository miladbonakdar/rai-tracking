using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Interfaces;
using Autofac;
using Domain.Interfaces;
using DomainEvent.Extensions;
using Infrastructure.Interfaces;
using SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        private static string _redisConnectionString = null;

        public static string RedisConnectionString
        {
            get => _redisConnectionString ?? throw new NullReferenceException();
            set => _redisConnectionString = string.IsNullOrWhiteSpace(_redisConnectionString)
                ? value
                : throw new InvalidOperationException();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().SingleInstance();

            builder.RegisterType<ApplicationCommandFactory>().As<IApplicationCommandFactory>()
                .InstancePerDependency();

            builder.RegisterType<CacheMultiplexer>().As<ICacheMultiplexer>()
                .SingleInstance();
            builder.RegisterType<CacheStore>().As<ICacheStore>()
                .SingleInstance();

            builder.RegisterType<SmsService>().As<ISmsService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Commander>().As<ICommander>()
                .InstancePerLifetimeScope();
        }
    }
}