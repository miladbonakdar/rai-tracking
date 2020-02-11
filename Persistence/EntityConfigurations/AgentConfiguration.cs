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
            builder.Property(a => a.Email).IsUnicode();
            builder.Property(a => a.PhoneNumber).IsUnicode();
        }
    }
}