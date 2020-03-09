using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Constants;

namespace Persistence.EntityConfigurations
{
    class AdminConfiguration : IEntityConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.OwnsOne(a => a.PersonName);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(a => a.AdminType).HasDefaultValue(Constants.UserType.Agent);
        }
    }
}