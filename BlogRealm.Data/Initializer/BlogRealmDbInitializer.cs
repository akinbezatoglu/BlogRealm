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

            var users = new List<User>
            {
                new User { Id = 1, Username = "admin-user", Password = "your-strong-password", RoleId = 1 },
                new User { Id = 2, Username = "sophiabrown", Password = "deneme", RoleId = 3 },
                new User { Id = 3, Username = "davidmiller", Password = "deneme", RoleId = 3 },
                new User { Id = 4, Username = "oliviadavis", Password = "deneme", RoleId = 3 },
                new User { Id = 5, Username = "jamesgarcia", Password = "deneme", RoleId = 3 },
                new User { Id = 6, Username = "emilymartinez", Password = "deneme", RoleId = 3 },
                new User { Id = 7, Username = "emmajohnson", Password = "deneme", RoleId = 3 },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author { Id = 1, UserId = 2, Fullname = "Sophia Brown", Image = "/miniblog/images/person_1.jpg", About = " Sophia Brown is a renowned fantasy author, creating immersive worlds filled with magic and adventure. Her richly detailed settings and well-developed characters have garnered her a loyal following among fantasy enthusiasts." },
                new Author { Id = 2, UserId = 3, Fullname = "David Miller", Image = "/miniblog/images/person_2.jpg", About = "David Miller is a prolific science fiction writer. His books explore futuristic technologies and dystopian societies, provoking thought about the ethical implications of scientific advancements and the future of humanity." },
                new Author { Id = 3, UserId = 4, Fullname = "Olivia Davis", Image = "/miniblog/images/person_3.jpg", About = "Olivia Davis is a prominent author in the contemporary fiction scene. Her stories often tackle social issues and personal growth, providing insightful commentary on modern life and human connections." },
                new Author { Id = 4, UserId = 5, Fullname = "James Garcia", Image = "/miniblog/images/person_4.jpg", About = "James Garcia is an award-winning author known for his gripping crime thrillers. His background in law enforcement adds a layer of realism to his novels, which are praised for their fast-paced narratives and complex characters." },
                new Author { Id = 5, UserId = 6, Fullname = "Emily Martinez", Image = "/miniblog/images/person_5.jpg", About = "Emily Martinez is a distinguished children's book author. Her enchanting tales and vibrant illustrations inspire young readers, promoting imagination and a love for reading from an early age." },
                new Author { Id = 6, UserId = 7, Fullname = "Emma Johnson", Image = "/miniblog/images/person_3.jpg", About = "Emma Johnson is a celebrated writer in the romance genre. Her novels often explore complex relationships and emotional journeys, resonating deeply with her audience and earning her numerous accolades." },
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

            context.Abouts.Add(new About
            {
                MainContentTitle = "About Us",
                MainContentImage = "/miniblog/images/img_4.jpg",
                MainContent = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorem, adipisci?",
                FirstContentTitle = "We Love To Explore",
                FirstContentImage = "/miniblog/images/img_1.jpg",
                FirstContent = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ea voluptate odit corrupti vitae cupiditate explicabo, soluta quibusdam necessitatibus, provident reprehenderit, dolorem saepe non eligendi possimus autem repellendus nesciunt, est deleniti libero recusandae officiis. Voluptatibus quisquam voluptatum expedita recusandae architecto quibusdam.",
                SecondContentTitle = "Learn From Us",
                SecondContentImage = "/miniblog/images/img_1.jpg",
                SecondContent = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ea voluptate odit corrupti vitae cupiditate explicabo, soluta quibusdam necessitatibus, provident reprehenderit, dolorem saepe non eligendi possimus autem repellendus nesciunt, est deleniti libero recusandae officiis. Voluptatibus quisquam voluptatum expedita recusandae architecto quibusdam.",
            });
            context.SaveChanges();

            context.Contacts.Add(new Contact
            {
                Fullname = "Isabella Hernandez",
                Email = "isabella@hernandez.com",
                Subject = "Request to Add New Blog to BlogRealm",
                Message = "I hope this message finds you well.\r\n\r\nI am writing to request the addition of a new blog to BlogRealm. My name is Isabella Hernandez, and I am an avid writer with a passion for [your blog's main topic, e.g., \"contemporary literature,\" \"food and travel,\" etc.]. I believe that my blog would be a great fit for your platform and would offer valuable content to your readers."
            });
            context.SaveChanges();

            context.Newsletters.Add(new Newsletter { Email = "isabella@hernandez.com" });
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Sports", About = "Dive into the latest news, trends, and insights from the world of sports. From game analysis and player profiles to fitness tips and sports science, stay updated on everything that fuels your passion for sports.", ColorHexCode = "#FF5733" },
                new Category { Id = 2, Name = "Travel", About = "Explore destinations around the globe, get travel tips, and find inspiration for your next adventure. Whether you're looking for budget travel hacks or luxury experiences, our travel blog has something for every wanderlust spirit.", ColorHexCode = "#33FF57" },
                new Category { Id = 3, Name = "Technology", About = "Stay ahead with the latest in technology. Discover new gadgets, software reviews, tech trends, and in-depth analysis of how technology is shaping our world. Perfect for tech enthusiasts and professionals alike.", ColorHexCode = "#3357FF" },
                new Category { Id = 4, Name = "Health", About = "Your go-to source for health and wellness advice. Learn about fitness routines, healthy eating, mental health, and the latest medical research. Empower yourself with the knowledge to live a healthier life.", ColorHexCode = "#FF33A1" },
                new Category { Id = 5, Name = "Food", About = "Indulge in the world of food with recipes, cooking tips, restaurant reviews, and culinary trends. From gourmet dishes to simple home-cooked meals, satisfy your taste buds and culinary curiosity.", ColorHexCode = "#A1FF33" },
                new Category { Id = 6, Name = "Lifestyle", About = "Enhance your lifestyle with tips on fashion, home decor, beauty, and personal development. Discover ways to improve your everyday living and find inspiration for a more fulfilling life.", ColorHexCode = "#5733FF" },
                new Category { Id = 7, Name = "Education", About = "Stay informed about the latest in education. Explore teaching methods, educational technology, and tips for students and educators. Whether you're a parent, teacher, or lifelong learner, find valuable insights here.", ColorHexCode = "#FFB533" },
                new Category { Id = 8, Name = "Parenting", About = "Navigate the joys and challenges of parenting with advice, tips, and personal stories. From newborn care to teenage guidance, find resources to support you in raising happy, healthy children.", ColorHexCode = "#33FFA1" },
                new Category { Id = 9, Name = "Entertainment", About = "Get your fix of entertainment news, movie and TV show reviews, music updates, and celebrity gossip. Stay in the loop with what's happening in the world of entertainment and pop culture.", ColorHexCode = "#FF33D4" },
                new Category { Id = 10, Name = "Finance", About = "Empower yourself with financial knowledge. Learn about budgeting, investing, saving, and the latest in financial technology. Whether you're planning for retirement or just starting out, find tips to manage your money better.", ColorHexCode = "#33A1FF" },
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            string blogContentHtml = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Praesentium nam quas inventore, ut iure iste modi eos adipisci ad ea itaque labore earum autem nobis et numquam, minima eius. Nam eius, non unde ut aut sunt eveniet rerum repellendus porro.</p>\r\n<p>Sint ab voluptates itaque, ipsum porro qui obcaecati cumque quas sit vel. Voluptatum provident id quis quo. Eveniet maiores perferendis officia veniam est laborum, expedita fuga doloribus natus repellendus dolorem ab similique sint eius cupiditate necessitatibus, magni nesciunt ex eos.</p>\r\n<p>Quis eius aspernatur, eaque culpa cumque reiciendis, nobis at earum assumenda similique ut? Aperiam vel aut, ex exercitationem eos consequuntur eaque culpa totam, deserunt, aspernatur quae eveniet hic provident ullam tempora error repudiandae sapiente illum rerum itaque voluptatem. Commodi, sequi.</p>\r\n<div class=\"row mb-5 mt-5\">\r\n  <div class=\"col-md-12 mb-4\">\r\n    <img src=\"images/img_1.jpg\" alt=\"Image placeholder\" class=\"img-fluid rounded\">\r\n  </div>\r\n  <div class=\"col-md-6 mb-4\">\r\n    <img src=\"images/img_2.jpg\" alt=\"Image placeholder\" class=\"img-fluid rounded\">\r\n  </div>\r\n  <div class=\"col-md-6 mb-4\">\r\n    <img src=\"images/img_3.jpg\" alt=\"Image placeholder\" class=\"img-fluid rounded\">\r\n  </div>\r\n</div>\r\n<p>Quibusdam autem, quas molestias recusandae aperiam molestiae modi qui ipsam vel. Placeat tenetur veritatis tempore quos impedit dicta, error autem, quae sint inventore ipsa quidem. Quo voluptate quisquam reiciendis, minus, animi minima eum officia doloremque repellat eos, odio doloribus cum.</p>\r\n<p>Temporibus quo dolore veritatis doloribus delectus dolores perspiciatis recusandae ducimus, nisi quod, incidunt ut quaerat, magnam cupiditate. Aut, laboriosam magnam, nobis dolore fugiat impedit necessitatibus nisi cupiditate, quas repellat itaque molestias sit libero voluptas eveniet omnis illo ullam dolorem minima.</p>\r\n<p>Porro amet accusantium libero fugit totam, deserunt ipsa, dolorem, vero expedita illo similique saepe nisi deleniti. Cumque, laboriosam, porro! Facilis voluptatem sequi nulla quidem, provident eius quos pariatur maxime sapiente illo nostrum quibusdam aliquid fugiat! Earum quod fuga id officia.</p>\r\n<p>Illo magnam at dolore ad enim fugiat ut maxime facilis autem, nulla cumque quis commodi eos nisi unde soluta, ipsa eius aspernatur sint atque! Nihil, eveniet illo ea, mollitia fuga accusamus dolor dolorem perspiciatis rerum hic, consectetur error rem aspernatur!</p>\r\n<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus magni explicabo id molestiae, minima quas assumenda consectetur, nobis neque rem, incidunt quam tempore perferendis provident obcaecati sapiente, animi vel expedita omnis quae ipsa! Obcaecati eligendi sed odio labore vero reiciendis facere accusamus molestias eaque impedit, consequuntur quae fuga vitae fugit?</p>";
            context.Blogs.AddRange(new List<Blog>
            {
                new Blog { Id = 1, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-251), Content = blogContentHtml, CategoryId = 1, AuthorId = 1 },
                new Blog { Id = 2, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-227), Content = blogContentHtml, CategoryId = 1, AuthorId = 2 },
                new Blog { Id = 3, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-198), Content = blogContentHtml, CategoryId = 1, AuthorId = 3 },
                new Blog { Id = 4, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-181), Content = blogContentHtml, CategoryId = 2, AuthorId = 4 },
                new Blog { Id = 5, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-144), Content = blogContentHtml, CategoryId = 2, AuthorId = 5 },
                new Blog { Id = 6, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-127), Content = blogContentHtml, CategoryId = 3, AuthorId = 6 },
                new Blog { Id = 7, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-102), Content = blogContentHtml, CategoryId = 3, AuthorId = 1 },
                new Blog { Id = 8, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-89), Content = blogContentHtml, CategoryId = 4, AuthorId = 2 },
                new Blog { Id = 9, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-76), Content = blogContentHtml, CategoryId = 4, AuthorId = 3 },
                new Blog { Id = 10, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-65), Content = blogContentHtml, CategoryId = 4, AuthorId = 4 },
                new Blog { Id = 11, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-54), Content = blogContentHtml, CategoryId = 5, AuthorId = 5 },
                new Blog { Id = 12, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-45), Content = blogContentHtml, CategoryId = 5, AuthorId = 6 },
                new Blog { Id = 13, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-36), Content = blogContentHtml, CategoryId = 5, AuthorId = 1 },
                new Blog { Id = 14, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-28), Content = blogContentHtml, CategoryId = 6, AuthorId = 2 },
                new Blog { Id = 15, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-20), Content = blogContentHtml, CategoryId = 6, AuthorId = 3 },
                new Blog { Id = 16, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-15), Content = blogContentHtml, CategoryId = 7, AuthorId = 4 },
                new Blog { Id = 17, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-10), Content = blogContentHtml, CategoryId = 7, AuthorId = 5 },
                new Blog { Id = 18, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-7), Content = blogContentHtml, CategoryId = 7, AuthorId = 6 },
                new Blog { Id = 19, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-6), Content = blogContentHtml, CategoryId = 8, AuthorId = 1 },
                new Blog { Id = 20, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-5), Content = blogContentHtml, CategoryId = 8, AuthorId = 2 },
                new Blog { Id = 21, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_1.jpg", Date = DateTime.UtcNow.AddDays(-4), Content = blogContentHtml, CategoryId = 9, AuthorId = 3 },
                new Blog { Id = 22, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow.AddDays(-3), Content = blogContentHtml, CategoryId = 9, AuthorId = 4 },
                new Blog { Id = 23, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_3.jpg", Date = DateTime.UtcNow.AddDays(-2), Content = blogContentHtml, CategoryId = 10, AuthorId = 5 },
                new Blog { Id = 24, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_4.jpg", Date = DateTime.UtcNow.AddDays(-1), Content = blogContentHtml, CategoryId = 10, AuthorId = 6 },
                new Blog { Id = 25, Title = "The AI magically removes moving objects from videos.", Image = "/miniblog/images/img_2.jpg", Date = DateTime.UtcNow, Content = blogContentHtml, CategoryId = 10, AuthorId = 1 },
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
