using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entity;
using DomainLayer.Repository_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly string connectionstring;
        public static UserDTO userOne = new UserDTO();

        public UserRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task RegisterAsync(UserDTO user)
        {
            HashPassword(user.Password, out byte[] PassSalt, out byte[] PassHash); 
            using (var connection = new SqlConnection(connectionstring))
            {


                var authuser_table_query = "INSERT INTO Users(UserName,Email,PasswordHash,PasswordSalt,Roles) OUTPUT INSERTED.Id VALUES(@UserName,@Email,@PasswordHash,@PasswordSalt,@Roles)";
                var userdetails_table_query = "INSERT INTO UserDetails(AuthUserId) VALUES(@AuthUserId)";
                var authUserId = await connection.QuerySingleAsync<int>(authuser_table_query, new
                {
                    @UserName = user.UserName,
                    @Email = user.Email,
                    @PasswordHash = PassHash,
                    @PasswordSalt = PassSalt,
                    @Roles = "User"
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

        /*public async Task<bool> LoginAsync(UserDTO user)
        {
            using (var connection = new SqlConnection(connectionstring))
            {

                var query = "SELECT count(*) from Users WHERE Email=@Email";
                var result = connection.ExecuteScalar<int>(query, user);
                if (result>0)
                {
                    var querySecond = "SELECT * FROM Users WHERE Email=@Email";
                    var data = await connection.QueryFirstOrDefaultAsync<User>(querySecond, userOne.Email);
                    if (!CheckPassword(user.Password, data.AuthUsers.PasswordSalt, data.AuthUsers.PasswordHash))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    throw new Exception("User not found!");
                }
            }

        }
*/
        public async Task LoginAsync(UserDTO user)
        {
            HashPassword(user.Password, out byte[] PassSalt, out byte[] PassHash); 
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Users WHERE Email=@Email";
                var data = await connection.QueryFirstOrDefaultAsync<User>(query, new
                {
                    @Email = user.Email
                });
                CheckPassword(user.Password, data.AuthUsers.PasswordSalt, data.AuthUsers.PasswordHash);
            }
        }


        private bool CheckPassword(string password, byte[] passSalt, byte[] passHash)
        {
            using (var hmac = new HMACSHA512(passSalt))
            {
                var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedPass.SequenceEqual(passHash);
            }
        }

        public async Task UpdateAsync(EditUserDTO user)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "UPDATE UserDetails SET FirstName=@FirstName,LastName=@LastName,@Address=Address,DoB=@DoB WHERE AuthUserId=@AuthUserId";
                await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<EditUserDTO> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM UserDetails WHERE AuthUserId=@Id";
                var data = await connection.QueryFirstOrDefaultAsync<EditUserDTO>(query, new
                {
                    @Id = id
                });
                if (data != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("User not found!");
                }

            }
        }
    }
}
