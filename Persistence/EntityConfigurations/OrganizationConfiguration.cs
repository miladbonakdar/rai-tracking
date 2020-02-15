using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class OrganizationConfiguration : IEntityConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasIndex(o => o.Code).IsUnique();
            builder.HasIndex(o => o.Name).IsUnique();
            builder.OwnsOne(o => o.Location);
        }
    }
}