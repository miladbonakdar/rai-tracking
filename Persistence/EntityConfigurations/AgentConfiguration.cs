using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class AgentConfiguration : IEntityConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.OwnsOne(a => a.PersonName);
            builder.OwnsOne(a => a.LastLocation);
            builder.OwnsOne(a => a.AgentInfo);
            builder.OwnsOne(a => a.AgentSetting);
            builder.HasIndex(a => a.PhoneNumber).IsUnique();
            builder.HasIndex(a => a.Email).IsUnique();
        }
    }
}