using BlogRealm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogRealm.Data.Configurations
{
    public class CommentConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Comment> commentConfiguration)
        {
            commentConfiguration.HasKey(c => c.Id);

            commentConfiguration.Property(c => c.Fullname)
                .IsRequired()
                .HasMaxLength(250);

            commentConfiguration.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(750);

            commentConfiguration.Property(c => c.CreatedDateTime)
                .IsRequired();
        }
    }
}
