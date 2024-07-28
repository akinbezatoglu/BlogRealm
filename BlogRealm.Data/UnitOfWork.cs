using BlogRealm.Core;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using BlogRealm.Data.Repositories;
using System.Threading.Tasks;

namespace BlogRealm.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogRealmDbContext _context;

        private AboutRepository _aboutRepository;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private ContactRepository _contactRepository;
        private NewsletterRepository _newsletterRepository;
        private RoleRepository _roleRepository;
        private SocialMediaAccountRepository _socialMediaAccountRepository;
        private SocialMediaPlatformRepository _socialMediaPlatformRepository;
        private UserRepository _userRepository;

        public UnitOfWork(BlogRealmDbContext context)
        {
            this._context = context;
        }

        public IAboutRepository Abouts => _aboutRepository = _aboutRepository ?? new AboutRepository(_context);
        public IAuthorRepository Authors => _authorRepository = _authorRepository ?? new AuthorRepository(_context);
        public IBlogRepository Blogs => _blogRepository = _blogRepository ?? new BlogRepository(_context);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository = _commentRepository ?? new CommentRepository(_context);
        public IContactRepository Contacts => _contactRepository = _contactRepository ?? new ContactRepository(_context);
        public INewsletterRepository Newsletters => _newsletterRepository = _newsletterRepository ?? new NewsletterRepository(_context);
        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);
        public ISocialMediaAccountRepository SocialMediaAccounts => _socialMediaAccountRepository = _socialMediaAccountRepository ?? new SocialMediaAccountRepository(_context);
        public ISocialMediaPlatformRepository SocialMediaPlatforms => _socialMediaPlatformRepository = _socialMediaPlatformRepository ?? new SocialMediaPlatformRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}