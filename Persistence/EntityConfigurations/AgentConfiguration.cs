using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class AgentConfiguration : IEntityConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            
        }
    }
}