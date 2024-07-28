using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class UserConfiguration
    {
        public static void Configure(EntityTypeConfiguration<User> userConfig)
        {
            userConfig.HasKey(a => a.Id);

            userConfig.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(250);

            userConfig.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
