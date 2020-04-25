using System;
using Application.Interfaces;
using Autofac;
using Infrastructure.Interfaces;
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

            builder.RegisterType<CacheMultiplexer>().As<ICacheMultiplexer>()
                .SingleInstance();
            builder.RegisterType<CacheStore>().As<ICacheStore>()
                .SingleInstance();

            builder.RegisterType<SmsService>().As<ISmsService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Commander>().As<ICommander>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PasswordService>().As<IPasswordService>().As<IHasher>()
                .InstancePerDependency();
        }
    }
}