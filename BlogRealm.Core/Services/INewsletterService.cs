using BlogRealm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface INewsletterService
    {
        Task<Newsletter> GetById(int id);
        Task<Newsletter> AddtoNewsletter(Newsletter newsletter);
        Task<IEnumerable<Newsletter>> GetAll();
        Task DeleteSubscriber(Newsletter newsletter);
    }
}
