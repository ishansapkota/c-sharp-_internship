﻿using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository iUser;

        public UserService(IUserRepository _iUser)
        {
            iUser = _iUser;
        }
        public async Task RegisterUserAsync(UserDTO user)
        {
            await iUser.RegisterAsync(user);
        }
        public async Task AdminRegisterAsync(UserDTO user)
        {
            await iUser.RegisterAdminAsync(user);
        }
        public async Task UpdateUserAsync(EditUserDTO user,int id)
        {
            await iUser.UpdateAsync(user,id);
        }

        public async Task<EditUserDTO> GetUserByIdAsync(int id)
        {
            var data = await iUser.GetByIdAsync(id);
            return data;
        }
        /*public async Task<bool> LoginUserAsync(UserDTO user)
        {
            var result = await iUser.LoginAsync(user);
            return result;
        }*/

        public async Task<string> LoginUserAsync(UserDTO user)
        {
            var result = await iUser.LoginAsync(user);
            return result;
        }

        public async Task<IEnumerable<EditUserDTO>> GetAllUsersAsync()
        {

            var result = await iUser.GetAllAsync();
            return result;
        }
    }
}
