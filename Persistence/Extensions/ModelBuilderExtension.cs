using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using SharedKernel;

namespace Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Configure<TConfiguration, TEntity>(this ModelBuilder builder) where
            TConfiguration : IEntityConfiguration<TEntity>, new()
            where TEntity : class
        {
            if (!AppDbContext.IgnoredForDefaultModelConfiguration().Contains(typeof(TEntity)))
                builder.SharedConfiguration<TEntity>();
            var configuration = new TConfiguration();
            configuration.Configure(builder.Entity<TEntity>());
        }

        private static void SharedConfiguration<TEntity>(this ModelBuilder builder) where
            TEntity : class
        {
            builder.Entity<TEntity>().Property<DateTime>(ShadowPropertyKeys.CreatedById).IsRequired();
            builder.Entity<TEntity>().Property<DateTime>(ShadowPropertyKeys.UpdatedById);
            builder.Entity<TEntity>().Property<DateTime>(ShadowPropertyKeys.CreatedAt).IsRequired();
            builder.Entity<TEntity>().Property<DateTime>(ShadowPropertyKeys.UpdatedAt);
            builder.Entity<TEntity>().Property<string>(ShadowPropertyKeys.CreatedBy)
                .HasMaxLength(200);
            builder.Entity<TEntity>().Property<string>(ShadowPropertyKeys.UpdatedBy)
                .HasMaxLength(200);
        }
    }
}