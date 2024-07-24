﻿using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserDTO user);
        Task AdminRegisterAsync(UserDTO user);
        Task UpdateUserAsync(EditUserDTO user,int id);
        Task<EditUserDTO> GetUserByIdAsync(int id);
        /*Task<bool> LoginUserAsync(UserDTO user);*/
        Task<string> LoginUserAsync(UserDTO user);

        Task<IEnumerable<EditUserDTO>> GetAllUsersAsync();
    }
}
