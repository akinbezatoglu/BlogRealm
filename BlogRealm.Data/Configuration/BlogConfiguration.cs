using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class BlogConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Blog> blogConfig)
        {
            blogConfig.HasKey(b => b.Id);

            blogConfig.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(300);

            blogConfig.Property(b => b.Image)
                .IsRequired()
                .HasMaxLength(500);

            blogConfig.Property(b => b.Date)
                .IsRequired();

            blogConfig.Property(b => b.Content)
                .IsRequired()
                .HasMaxLength(5000);

            blogConfig.HasMany(b => b.Comments)
                .WithRequired(c => c.Blog)
                .HasForeignKey(c => c.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
