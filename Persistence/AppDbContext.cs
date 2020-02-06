using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Persistence
{
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private DbSet<Agent> Agents { set; get; }
        private DbSet<Command> Commands { set; get; }
        private DbSet<Depo> Depos { set; get; }
        private DbSet<Mission> Missions { set; get; }
        private DbSet<Organization> Organizations { set; get; }
        private DbSet<Station> Stations { set; get; }
        private DbSet<User> Users { set; get; }

        public static DbContextOptions<AppDbContext> DbContextOptionsFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(PersistenceModule.PgConnectionString);
            return optionsBuilder.Options;
        }
    }
}