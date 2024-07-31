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
    public class TableService:ITableService
    {
        private readonly ITableRepository iRepo;

        public TableService(ITableRepository _iRepo)
        {
            iRepo = _iRepo;
        }

        public async Task AddTeamAsync(TeamDTO team)
        {
            await iRepo.AddAsync(team);
        }

        public async Task UpdateTeamAsync(int id,TeamDTO team)
        {
            await iRepo.UpdateAsync(id,team);
        }
        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
        {
            return await iRepo.GetAllAsync();
        }

        public async Task<TeamDTO> GetSingleTeamAsync(int id)
        {
            return await iRepo.GetByIdAsync(id);
        }
    }
}
