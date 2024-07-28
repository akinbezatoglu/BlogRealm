using BlogRealm.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BlogRealm.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAboutRepository Abouts { get; }
        IAuthorRepository Authors { get; }
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IContactRepository Contacts { get; }
        INewsletterRepository Newsletters { get; }
        IRoleRepository Roles { get; }
        ISocialMediaAccountRepository SocialMediaAccounts { get; }
        ISocialMediaPlatformRepository SocialMediaPlatforms { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
