using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface ITableRepository
    {
        Task AddAsync(TeamDTO team);
        Task UpdateAsync(int id,TeamDTO team);

        Task<IEnumerable<TeamDTO>> GetAllAsync();

        Task<TeamDTO> GetByIdAsync(int id);
    }
}
