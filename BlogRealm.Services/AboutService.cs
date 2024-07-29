using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AboutService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<About> GetAbout()
        {
            return await _unitOfWork.Abouts.GetFirstAsync();
        }

        public async Task UpdateAbout(About aboutToBeUpdated, About about)
        {
            aboutToBeUpdated.MainContent = about.MainContent;
            aboutToBeUpdated.MainContentImage = about.MainContentImage;
            aboutToBeUpdated.MainContentTitle = about.MainContentTitle;

            aboutToBeUpdated.FirstContent = about.FirstContent;
            aboutToBeUpdated.FirstContentImage = about.FirstContentImage;
            aboutToBeUpdated.FirstContentTitle = about.FirstContentTitle;

            aboutToBeUpdated.SecondContent = about.SecondContent;
            aboutToBeUpdated.SecondContentImage = about.SecondContentImage;
            aboutToBeUpdated.SecondContentTitle = about.SecondContentTitle;

            await _unitOfWork.CommitAsync();
        }
    }
}
