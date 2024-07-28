using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class SocialMediaAccountConfiguration
    {
        public static void Configure(EntityTypeConfiguration<SocialMediaAccount> socialMediaAccountConfig)
        {
            socialMediaAccountConfig.HasKey(s => s.Id);

            socialMediaAccountConfig.Property(s => s.Username)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
