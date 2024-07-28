using BlogRealm.Core.Models;
using BlogRealm.Data.Configurations;
using BlogRealm.Data.Initializer;
using System.Data.Entity;

namespace BlogRealm.Data.Context
{
    public class BlogRealmDbContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<SocialMediaPlatform> SocialMediaPlatforms { get; set; }
        public DbSet<User> Users { get; set; }

        public BlogRealmDbContext() : base("name=BlogRealmDbContext")
        {
            Database.SetInitializer<BlogRealmDbContext>(new BlogRealmDbInitializer());
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AboutConfiguration.Configure(modelBuilder.Entity<About>());
            AuthorConfiguration.Configure(modelBuilder.Entity<Author>());
            BlogConfiguration.Configure(modelBuilder.Entity<Blog>());
            CategoryConfiguration.Configure(modelBuilder.Entity<Category>());
            CommentConfiguration.Configure(modelBuilder.Entity<Comment>());
            ContactConfiguration.Configure(modelBuilder.Entity<Contact>());
            NewsletterConfiguration.Configure(modelBuilder.Entity<Newsletter>());
            RoleConfiguration.Configure(modelBuilder.Entity<Role>());
            SocialMediaAccountConfiguration.Configure(modelBuilder.Entity<SocialMediaAccount>());
            SocialMediaPlatformConfiguration.Configure(modelBuilder.Entity<SocialMediaPlatform>());
            UserConfiguration.Configure(modelBuilder.Entity<User>());
        }
    }
}
