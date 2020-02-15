using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using Persistence.Extensions;

namespace Persistence
{
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure<AgentConfiguration, Agent>();
            modelBuilder.Configure<AgentEventConfiguration, AgentEvent>();
            modelBuilder.Configure<CommandConfiguration, Command>();
            modelBuilder.Configure<DepoConfiguration, Depo>();
            modelBuilder.Configure<MissionConfiguration, Mission>();
            modelBuilder.Configure<MissionLocationConfiguration, MissionLocation>();
            modelBuilder.Configure<MissionEventConfiguration, MissionEvent>();
            modelBuilder.Configure<OrganizationConfiguration, Organization>();
            modelBuilder.Configure<StationConfiguration, Station>();
            modelBuilder.Configure<AdminConfiguration, Admin>();
        }

        private DbSet<Agent> Agents { set; get; }
        private DbSet<Command> Commands { set; get; }
        private DbSet<Depo> Depos { set; get; }
        private DbSet<Mission> Missions { set; get; }
        private DbSet<Organization> Organizations { set; get; }
        private DbSet<Station> Stations { set; get; }
        private DbSet<Admin> Admins { set; get; }

        public static DbContextOptions<AppDbContext> DbContextOptionsFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(PersistenceModule.PgConnectionString);
            return optionsBuilder.Options;
        }
    }
}