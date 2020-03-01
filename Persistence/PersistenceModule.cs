using System;
using Application.Interfaces;
using Autofac;

namespace Persistence
{
    public class PersistenceModule : Module
    {
        private static string _pgConnectionString = null;

        public static string PgConnectionString
        {
            get => _pgConnectionString ??
                   "User ID=postgres;Password=Xx123456P@ssw0rd;Host=localhost;Port=5432;Database=raitracking;Pooling=true;"
            ;
            set => _pgConnectionString = string.IsNullOrWhiteSpace(_pgConnectionString)
                ? value
                : throw new InvalidOperationException();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AppDbContext>()
                .WithParameter("options", AppDbContext.DbContextOptionsFactory())
                .AsSelf().InstancePerLifetimeScope();
            builder
                .RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}