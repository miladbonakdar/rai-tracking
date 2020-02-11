using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class AgentEventConfiguration : IEntityConfiguration<AgentEvent>
    {
        public void Configure(EntityTypeBuilder<AgentEvent> builder)
        {
            builder.OwnsOne(e => e.AgentLocation);
        }
    }
}