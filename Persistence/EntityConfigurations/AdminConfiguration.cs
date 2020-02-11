using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class AdminConfiguration : IEntityConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.OwnsOne(a => a.PersonName);
            builder.Property(a => a.Email).IsUnicode();
            builder.Property(a => a.PhoneNumber).IsUnicode();
        }
    }
}