using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class MissionLocationConfiguration : IEntityConfiguration<MissionLocation>
    {
        public void Configure(EntityTypeBuilder<MissionLocation> builder)
        {
            builder.OwnsOne(m => m.Location);
        }
    }
}