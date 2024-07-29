namespace BlogRealm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainContent = c.String(nullable: false, maxLength: 750),
                        MainContentTitle = c.String(nullable: false, maxLength: 300),
                        MainContentImage = c.String(nullable: false, maxLength: 500),
                        FirstContent = c.String(nullable: false, maxLength: 750),
                        FirstContentTitle = c.String(nullable: false, maxLength: 300),
                        FirstContentImage = c.String(nullable: false, maxLength: 500),
                        SecondContent = c.String(nullable: false, maxLength: 750),
                        SecondContentTitle = c.String(nullable: false, maxLength: 300),
                        SecondContentImage = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 300),
                        Image = c.String(nullable: false, maxLength: 500),
                        About = c.String(nullable: false, maxLength: 750),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        Image = c.String(nullable: false, maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        About = c.String(nullable: false, maxLength: 850),
                        ColorHexCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, maxLength: 750),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.SocialMediaAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        PlatformId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialMediaPlatforms", t => t.PlatformId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.PlatformId);
            
            CreateTable(
                "dbo.SocialMediaPlatforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        DefaultUrl = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Subject = c.String(nullable: false, maxLength: 250),
                        Message = c.String(nullable: false, maxLength: 1500),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.SocialMediaAccounts", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.SocialMediaAccounts", "PlatformId", "dbo.SocialMediaPlatforms");
            DropForeignKey("dbo.Blogs", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "PlatformId" });
            DropIndex("dbo.SocialMediaAccounts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "AuthorId" });
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropIndex("dbo.Authors", new[] { "UserId" });
            DropTable("dbo.Newsletters");
            DropTable("dbo.Contacts");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.SocialMediaPlatforms");
            DropTable("dbo.SocialMediaAccounts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
            DropTable("dbo.Abouts");
        }
    }
}
