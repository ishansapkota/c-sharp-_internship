using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository iRepo;

        public NewsService(INewsRepository _iRepo)
        {
            iRepo = _iRepo;
        }

        public async Task AddNewsAsync(NewsDTO news)
        {
            await iRepo.AddAsync(news);
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            var news = await iRepo.GetAllAsync();
            return news;
        }

        public async Task DeleteNewsAsync(int id)
        {
            await iRepo.Delete(id);
        }
    }
}
