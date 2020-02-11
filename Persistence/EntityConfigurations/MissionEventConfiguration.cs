using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class MissionEventConfiguration : IEntityConfiguration<MissionEvent>
    {
        public void Configure(EntityTypeBuilder<MissionEvent> builder)
        {
            builder.OwnsOne(e => e.AgentLocation);
        }
    }
}