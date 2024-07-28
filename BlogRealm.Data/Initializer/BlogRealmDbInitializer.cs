using BlogRealm.Core.Models;
using BlogRealm.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogRealm.Data.Initializer
{
    public class BlogRealmDbInitializer : CreateDatabaseIfNotExists<BlogRealmDbContext>
    {
        protected override void Seed(BlogRealmDbContext context)
        {
            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "moderator" },
                new Role { Id = 3, Name = "author" },
                new Role { Id = 4, Name = "readonly" },
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();

            var user = new User { Id = 1, Username = "admin-user", Password = "your-strong-password", RoleId = 1 };
            context.Users.Add(user);
            context.SaveChanges();

            var socialMediaPlatforms = new List<SocialMediaPlatform>
            {
                new SocialMediaPlatform { Id = 1, Name = "facebook", DefaultUrl = "https://www.facebook.com/" },
                new SocialMediaPlatform { Id = 2, Name = "instagram", DefaultUrl = "https://www.instagram.com/" },
                new SocialMediaPlatform { Id = 3, Name = "twitter", DefaultUrl = "https://x.com/" },
                new SocialMediaPlatform { Id = 4, Name = "youtube", DefaultUrl = "https://www.youtube.com/@" },
                new SocialMediaPlatform { Id = 5, Name = "tiktok", DefaultUrl = "https://www.tiktok.com/@" },
                new SocialMediaPlatform { Id = 6, Name = "reddit", DefaultUrl = "https://www.reddit.com/user/" },
                new SocialMediaPlatform { Id = 7, Name = "linkedin", DefaultUrl = "https://www.linkedin.com/in/" },
            };
            context.SocialMediaPlatforms.AddRange(socialMediaPlatforms);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
