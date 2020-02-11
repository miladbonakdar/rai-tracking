using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class StationConfiguration : IEntityConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Property(s => s.Code).IsUnicode();
            builder.Property(s => s.Name).IsUnicode();
            builder.OwnsOne(l => l.Location);
            builder.HasOne(s => s.PostStation)
                .WithMany().HasForeignKey(s => s.PostStationId);
            builder.HasOne(s => s.PreStation)
                .WithMany().HasForeignKey(s => s.PreStationId);
        }
    }
}