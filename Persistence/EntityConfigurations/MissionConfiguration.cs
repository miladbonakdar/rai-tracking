using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class MissionConfiguration : IEntityConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            
        }
    }
}