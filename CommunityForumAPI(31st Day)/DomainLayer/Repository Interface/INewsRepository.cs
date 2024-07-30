using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface INewsRepository
    {
        Task AddAsync(NewsDTO news);

        Task<IEnumerable<NewsDTO>> GetAllAsync();
    }
}
