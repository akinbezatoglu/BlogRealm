using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class RoleConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Role> roleConfig)
        {
            roleConfig.HasKey(r => r.Id);

            roleConfig.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
