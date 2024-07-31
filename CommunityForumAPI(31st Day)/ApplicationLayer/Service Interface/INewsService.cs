using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface INewsService
    {

        Task AddNewsAsync(NewsDTO news);

        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();

        Task DeleteNewsAsync(int id);
    }
}
