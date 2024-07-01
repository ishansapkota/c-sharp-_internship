using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository iUserRepo;

        public UserService(IUserRepository _iUserRepo)
        {
            iUserRepo = _iUserRepo;
        }
        public void AddUser(UserDTO user)
        {
            iUserRepo.Add(user);
        }
    }
}
