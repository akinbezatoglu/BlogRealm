using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class AuthorConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Author> authorConfig)
        {
            authorConfig.HasKey(a => a.Id);

            authorConfig.Property(a => a.Fullname)
                .IsRequired()
                .HasMaxLength(300);

            authorConfig.Property(a => a.Image)
                .IsRequired()
                .HasMaxLength(500);

            authorConfig.Property(a => a.About)
                .IsRequired()
                .HasMaxLength(750);

            authorConfig.HasMany(a => a.Blogs)
                .WithRequired(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .WillCascadeOnDelete(false);

            authorConfig.HasMany(a => a.SocialMediaAccounts)
                .WithRequired(s => s.Author)
                .HasForeignKey(s => s.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}
