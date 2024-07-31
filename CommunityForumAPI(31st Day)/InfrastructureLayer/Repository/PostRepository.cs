using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entity;
using DomainLayer.Repository_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly string connectionstring;

        public PostRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<string> Add(PostDTO post, int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Posts(PostTitle,PostDescription,AuthUserId) VALUES (@PostTitle,@PostDescription,@AuthUserId)";
                await connection.ExecuteAsync(query, new
                {
                    @PostTitle = post.PostTitle,
                    @PostDescription = post.PostDescription,
                    @AuthUserId = id
                });

                return "The Post has been Added.";
            }
        }

        public async Task<IEnumerable<PostWithUserDTO>> GetAll()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT p.Id,p.PostTitle,p.PostDescription,u.UserName,u.Email,ud.FirstName,ud.LastName from Posts p JOIN Users u ON p.AuthUserId = u.Id JOIN UserDetails ud ON u.Id = ud.AuthUserId WHERE p.IsApproved=1";
                var data = await connection.QueryAsync<PostWithUserDTO>(query);
                return data.ToList();
            }
        }

        public async Task<IEnumerable<PostWithUserDTO>> GetAllUnapproved()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT p.Id,p.PostTitle,p.PostDescription,u.UserName,u.Email,ud.FirstName,ud.LastName FROM Posts p JOIN Users u ON p.AuthUserId = u.Id JOIN UserDetails ud ON u.Id = ud.AuthUserId WHERE p.IsApproved = 0";
                var data = await connection.QueryAsync<PostWithUserDTO>(query);
                return data.ToList();
            }
        }

        public async Task Approve(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "UPDATE Posts SET IsApproved=1 WHERE Id=@Id";
                await connection.ExecuteAsync(query, new
                {
                    @Id = id
                });

            }
        }

        public async Task Delete(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "DELETE FROM Posts WHERE Id=@Id";
                await connection.ExecuteAsync(query, new
                {
                    @Id = id
                });
            }
        }


        public async Task<IEnumerable<PostWithUserDTO>> Retrieve(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT u.Email,u.UserName,p.PostTitle,p.Id,p.PostDescription,ud.FirstName,ud.LastName FROM Posts p JOIN Users u ON p.AuthUserId=u.Id JOIN UserDetails ud ON u.Id=ud.AuthUserId WHERE u.Id=@Id";
                var data = await connection.QueryAsync<PostWithUserDTO>(query, new
                {
                    @Id = id
                });

                return data.ToList();
            }
        }

        public async Task<PostWithUserDTO> RetrieveSingle(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT u.Email,u.UserName,p.PostTitle,p.Id,p.PostDescription,ud.FirstName,ud.LastName FROM Posts p JOIN Users u ON p.AuthUserId=u.Id JOIN UserDetails ud ON u.Id=ud.AuthUserId WHERE p.Id=@Id";
                var data = await connection.QueryFirstOrDefaultAsync<PostWithUserDTO>(query, new
                {
                    @Id = id
                });
                return data;
            }
        }

        public async Task DeletePostAsync(int id,int userId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var queryFirst = "DELETE FROM Posts WHERE Id = @Id AND AuthUserId=@UserId";
                var querySecond = "DELETE FROM CommentPostUsers WHERE PostId= @Id AND UserId=@UserId";
                await connection.ExecuteAsync(queryFirst, new
                {
                    @Id = id,
                    @UserId = userId
                });
                await connection.ExecuteAsync(querySecond, new
                {
                    @Id = id,
                    @UserId = userId
                });
               
            }
        }

    }
}
