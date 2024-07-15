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
    public class UserRepository:IUserRepository
    {
        private readonly string connectionstring;

        public UserRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public Task RegisterAsync(UserDTO user)
        {
            HashPassword(user.Password, out byte[] PassSalt, out byte[] PassHash); 
            using (var connection = new SqlConnection(connectionstring))
            {
                var authuser_table_query = "INSERT INTO Users(UserName,Email,PasswordHash,PasswordSalt) VALUES(@UserName,@Email,@PasswordHash,@PasswordSalt)";
                var userdetails_table_query = "INSERT INTO UserDetails(AuthUserId) VALUES(@AuthUserId)";
                connection.ExecuteAsync(authuser_table_query, new
                {
                    @UserName = user.UserName,
                    @Email = user.Email,
                    @PasswordHash = PassHash,
                    @PasswordSalt = PassSalt
                });

                connection.ExecuteAsync(userdetails_table_query, new
                {
                });
            }
        }

        private void HashPassword(string password, out byte[] passSalt, out byte[] passHash)
        {
            using(var hmac = new HMACSHA3_512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

    }
}
