using Dapper;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionstring;

        public UserRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }




        public void Add(UserDTO user)
        {
            HashPassword(user.Password, out byte[] passSalt, out byte[] passHash);
            using (var connection = new SqlConnection(connectionstring))
            {
                var auth_query = "INSERT INTO Users(Id,Email,PasswordSalt,PasswordHash) VALUES(@Id,@Email,@PasswordSalt,@PasswordHash)";
                var detail_query = "INSERT INTO UserDetails(FirstName,LastName,Address,DoB,AuthUserId) VALUES (@FirstName,@LastName,@Address,@DoB,@AuthUserId)";
                connection.Execute(auth_query, new
                {
                    @Id = user.AuthUserId,
                    @Email = user.Email,
                    @PasswordSalt = passSalt,
                    @PasswordHash = passHash
                });

                connection.Execute(detail_query, new
                {
                    @FirstName = user.FirstName,
                    @LastName = user.LastName,
                    @Address = user.Address,
                    @DoB = user.DoB,
                    @AuthUserId = user.AuthUserId
                });

            }
        }

        private void HashPassword(string Password, out byte[] PassSalt, out byte[] PassHash)
        {
            using (var hmac = new HMACSHA512())
            {
                PassSalt = hmac.Key;
                PassHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
            }
        }

        private bool CheckPassword(string Password,byte[] PassSalt,byte[] PassHash)
        {
            using(var hmac = new HMACSHA512(PassSalt))
            {
                var computedSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return computedSalt.SequenceEqual(PassHash);
            }
        }

    }
}
