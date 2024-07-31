using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface ITableService
    {
        Task AddTeamAsync(TeamDTO team);

        Task UpdateTeamAsync(int id,TeamDTO team);

        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();

        Task<TeamDTO> GetSingleTeamAsync(int id);
    }
}
