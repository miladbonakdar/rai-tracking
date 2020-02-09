using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class OrganizationConfiguration : IEntityConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            
        }
    }
}