using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class StationConfiguration : IEntityConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            
        }
    }
}