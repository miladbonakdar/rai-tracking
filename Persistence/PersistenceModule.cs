using System;
using Autofac;

namespace Persistence
{
    public class PersistenceModule : Module
    {
        private static string _pgConnectionString = null;

        public static string PgConnectionString
        {
            get => _pgConnectionString ?? throw new NullReferenceException();
            set => _pgConnectionString = string.IsNullOrWhiteSpace(_pgConnectionString)
                ? value
                : throw new InvalidOperationException();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AppDbContext>()
                .WithParameter("options", AppDbContext.DbContextOptionsFactory())
                .InstancePerLifetimeScope();
        }
    }
}