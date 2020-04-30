using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class MissionConfiguration : IEntityConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.OwnsOne(m => m.FailureLocation);
            builder.OwnsOne(m => m.ProbableFailureZone);
        }
    }
}