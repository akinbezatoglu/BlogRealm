using AutoMapper;
using BlogRealm.Core;
using BlogRealm.Core.Services;
using BlogRealm.Data;
using BlogRealm.Data.Context;
using BlogRealm.Services;
using BlogRealm.Web;
using BlogRealm.Web.App_Start;
using BlogRealm.Web.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "InitModules")]

namespace BlogRealm.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void InitModules()
        {
            RegisterModule(typeof(ScopedDependencyHttpModule));
        }

        protected void Application_Start()
        {
            ConfigureServices();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BlogRealmDbContext>();

            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<INewsletterService, NewsletterService>();
            services.AddTransient<ISocialMediaAccountService, SocialMediaAccountService>();
            services.AddTransient<ISocialMediaPlatformService, SocialMediaPlatformService>();
            services.AddTransient<IUserService, UserService>();

            var rootProvider = services.BuildServiceProvider(true);
            var resolver = new ScopedDependencyResolver(rootProvider);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
