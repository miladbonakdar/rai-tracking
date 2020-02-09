using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class AdminConfiguration : IEntityConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            
        }
    }
}