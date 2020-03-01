using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    class OrganizationConfiguration : IEntityConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasIndex(o => o.Code).IsUnique();
            builder.HasIndex(o => o.Name).IsUnique();
            builder.OwnsOne(o => o.Location);
            builder.HasData(new List<Organization>
            {
                new Organization(1, "ستاد", "000", true),
                new Organization(2, "نامعلوم", "999"),
                new Organization(8, "آذربایجان", "039"),
                new Organization(9, "اراک", "040"),
                new Organization(10, "اصفهان", "043"),
                new Organization(11, "تهران", "034"),
                new Organization(12, "قم", "137"),
                new Organization(13, "جنوب", "042"),
                new Organization(14, "یزد", "044"),
                new Organization(15, "خراسان", "037"),
                new Organization(16, "کرمان", "057"),
                new Organization(17, "جنوب شرق", "132"),
                new Organization(18, "شمال شرق 1", "036"),
                new Organization(19, "شمال", "035"),
                new Organization(20, "شمال غرب", "038"),
                new Organization(21, "لرستان", "136"),
                new Organization(22, "زاگرس", "041"),
                new Organization(23, "هرمزگان", "045"),
                new Organization(24, "شرق", "047"),
                new Organization(25, "فارس", "058"),
                new Organization(26, "شمال شرق 2", "138"),
            });
        }
    }
}