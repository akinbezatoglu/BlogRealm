using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class CategoryConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Category> categoryConfig)
        {
            categoryConfig.HasKey(c => c.Id);

            categoryConfig.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(250);

            categoryConfig.Property(c => c.About)
                .IsRequired()
                .HasMaxLength(850);

            categoryConfig.Property(c => c.ColorHexCode)
                .IsRequired()
                .HasMaxLength(10);

            categoryConfig.HasMany(c => c.Blogs)
                .WithRequired(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
