using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public interface IEntityConfiguration<TEntity> where TEntity : class
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}