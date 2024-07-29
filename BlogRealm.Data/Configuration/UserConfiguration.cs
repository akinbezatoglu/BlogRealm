using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class UserConfiguration
    {
        public static void Configure(EntityTypeConfiguration<User> userConfig)
        {
            userConfig.HasKey(u => u.Id);

            userConfig.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(250);

            userConfig.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(500);

            userConfig.HasRequired(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);
        }
    }
}
