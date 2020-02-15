using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class DepoConfiguration : IEntityConfiguration<Depo>
    {
        public void Configure(EntityTypeBuilder<Depo> builder)
        {
            builder.HasIndex(d => d.Name).IsUnique();
            builder.OwnsOne(d => d.Location);
        }
    }
}