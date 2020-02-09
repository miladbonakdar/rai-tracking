using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application;
using Application.Configurations;
using Application.Interfaces;
using Autofac;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Persistence;
using Serilog;

namespace RaiTracking.Extensions
{
    internal static class ContainerBuilderExtension
    {
        public static void RegisterApplicationComponents(this ContainerBuilder builder)
        {
            builder.RegisterApplicationModules();
            builder.RegisterConfigurationSetting();
            
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.Register(s => Log.Logger).SingleInstance();
            builder.RegisterType<AdminHub>().AsSelf().AsImplementedInterfaces().ExternallyOwned();
        }

        private static void RegisterConfigurationSetting(this ContainerBuilder builder)
        {
            builder.Register<IAppInformation>
                (s => s.Resolve<IOptions<AppInformation>>().Value).SingleInstance();
            builder.Register<IAppSetting>
                (s => s.Resolve<IOptions<AppSetting>>().Value).SingleInstance();
            builder.Register<IAuthSetting>
                (s => s.Resolve<IOptions<AuthSetting>>().Value).SingleInstance();
            builder.Register<ICorsSetting>
                (s => s.Resolve<IOptions<CorsSetting>>().Value).SingleInstance();
            builder.Register<ISerilogSetting>
                (s => s.Resolve<IOptions<SerilogSetting>>().Value).SingleInstance();
        }

        private static void RegisterApplicationModules(this ContainerBuilder builder) =>
            builder.RegisterAssemblyModules(new[]
            {
                Assembly.GetAssembly(typeof(InfrastructureModule)),
                Assembly.GetAssembly(typeof(PersistenceModule)),
                Assembly.GetAssembly(typeof(ApplicationModule)),
            });
    }
}
