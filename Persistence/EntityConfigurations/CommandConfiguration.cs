using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class CommandConfiguration : IEntityConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            
        }
    }
}