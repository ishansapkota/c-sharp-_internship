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
        public async Task RegisterAsync(UserDTO user)
        {
            HashPassword(user.Password, out byte[] PassSalt, out byte[] PassHash); 
            using (var connection = new SqlConnection(connectionstring))
            {


                var authuser_table_query = "INSERT INTO Users(UserName,Email,PasswordHash,PasswordSalt) OUTPUT INSERTED.Id VALUES(@UserName,@Email,@PasswordHash,@PasswordSalt)";
                var userdetails_table_query = "INSERT INTO UserDetails(AuthUserId) VALUES(@AuthUserId)";
                var authUserId = await connection.QuerySingleAsync<int>(authuser_table_query, new
                {
                    @UserName = user.UserName,
                    @Email = user.Email,
                    @PasswordHash = PassHash,
                    @PasswordSalt = PassSalt
                });

                await connection.ExecuteAsync(userdetails_table_query, new
                {
                    @AuthUserId = authUserId
                });
            }
        }

        private void HashPassword(string password, out byte[] passSalt, out byte[] passHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
        }

        public async Task UpdateAsync(EditUserDTO user)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "UPDATE UserDetails SET AS FirstName=@FirstName,LastName=@LastName,@Address=Address,DoB=@DoB WHERE Id=@Id";
                await connection.ExecuteAsync(query, user);
            }
        }

    }
}
