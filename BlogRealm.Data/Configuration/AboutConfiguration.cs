using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class AboutConfiguration
    {
        public static void Configure(EntityTypeConfiguration<About> aboutConfig)
        {
            aboutConfig.HasKey(a => a.Id);

            aboutConfig.Property(a => a.MainContentTitle)
                .IsRequired()
                .HasMaxLength(300);

            aboutConfig.Property(a => a.MainContent)
                .IsRequired()
                .HasMaxLength(750);

            aboutConfig.Property(a => a.MainContentImage)
                .IsRequired()
                .HasMaxLength(500);

            aboutConfig.Property(a => a.FirstContentTitle)
                .IsRequired()
                .HasMaxLength(300);

            aboutConfig.Property(a => a.FirstContent)
                .IsRequired()
                .HasMaxLength(750);

            aboutConfig.Property(a => a.FirstContentImage)
                .IsRequired()
                .HasMaxLength(500);

            aboutConfig.Property(a => a.SecondContentTitle)
                .IsRequired()
                .HasMaxLength(300);

            aboutConfig.Property(a => a.SecondContent)
                .IsRequired()
                .HasMaxLength(750);

            aboutConfig.Property(a => a.SecondContentImage)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
