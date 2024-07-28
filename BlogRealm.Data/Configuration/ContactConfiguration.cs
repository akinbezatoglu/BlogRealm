using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class ContactConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Contact> contactConfig)
        {
            contactConfig.HasKey(c => c.Id);

            contactConfig.Property(c => c.Fullname)
                .IsRequired()
                .HasMaxLength(250);

            contactConfig.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(250);

            contactConfig.Property(c => c.Subject)
                .IsRequired()
                .HasMaxLength(250);

            contactConfig.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(1500);

            contactConfig.Property(c => c.CreatedDateTime)
                .IsRequired();
        }
    }
}
