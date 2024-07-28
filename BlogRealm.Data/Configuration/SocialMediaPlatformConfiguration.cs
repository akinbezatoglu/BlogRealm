using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class SocialMediaPlatformConfiguration
    {
        public static void Configure(EntityTypeConfiguration<SocialMediaPlatform> socialMediaPlatformConfig)
        {
            socialMediaPlatformConfig.HasKey(s => s.Id);

            socialMediaPlatformConfig.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(300);

            socialMediaPlatformConfig.Property(s => s.DefaultUrl)
                .IsRequired()
                .HasMaxLength(300);

            socialMediaPlatformConfig.HasMany(p => p.SocialMediaAccounts)
                .WithRequired(a => a.SocialMediaPlatform)
                .HasForeignKey(a => a.PlatformId)
                .WillCascadeOnDelete(false);
        }
    }
}
