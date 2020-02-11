using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class OrganizationConfiguration : IEntityConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.Code).IsUnicode();
            builder.Property(o => o.Name).IsUnicode();
            builder.OwnsOne(o => o.Location);
        }
    }
}