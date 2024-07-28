using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class NewsletterConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Newsletter> newsletterConfig)
        {
            newsletterConfig.HasKey(n => n.Id);

            newsletterConfig.Property(n => n.Email)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
