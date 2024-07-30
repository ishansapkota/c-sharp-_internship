using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface IUserRepository
    {

        Task RegisterAsync(UserDTO user);

        Task RegisterAdminAsync(UserDTO user);

        Task UpdateAsync(EditUserDTO user,int id);

        Task<EditUserDTO> GetByIdAsync(int id);

        Task<string> LoginAsync(UserDTO user);
        /*Task LoginAsync(UserDTO user);*/

        Task<IEnumerable<EditUserDTO>> GetAllAsync();

    }
}
