using Dapper;
using DomainLayer.DTO;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly string connectionstring;

        public CommentRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task PostAsync(CommentDTO comment, int userId, int postId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Comments(CommentMessage) OUTPUT INSERTED.Id VALUES(@CommentMessage)";
                var commentId = await connection.ExecuteScalarAsync<int>(query, comment);

                var querySecond = "INSERT INTO CommentPostUsers(CommentId,UserId,PostId) VALUES (@CommentId,@UserId,@PostId)";
                await connection.ExecuteAsync(querySecond, new
                {
                    @CommentId = commentId,
                    @PostId = postId,
                    @UserId = userId
                });
            }
        }

        public async Task<IEnumerable<CommentWithUserandPostDTO>> GetByUserAsync(int userId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT ud.FirstName,ud.LastName,u.Email,u.UserName,c.CommentMessage,cpu.PostId,p.PostTitle,p.PostDescription FROM CommentPostUsers cpu JOIN UserDetails ud ON cpu.UserId=ud.AuthUserId JOIN Users u ON cpu.UserId=u.Id JOIN Comments c ON cpu.CommentId = c.Id JOIN Posts p ON cpu.PostId=p.Id WHERE UserId=@Id";
                var data = await connection.QueryAsync<CommentWithUserandPostDTO>(query, new
                {
                    @Id = userId
                });
                return data.ToList();
            }
        }

        public async Task<IEnumerable<CommentWithUserandPostDTO>> GetByPostAsync(int postId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT ud.FirstName,ud.LastName,u.Email,u.UserName,c.CommentMessage FROM CommentPostUsers cpu JOIN UserDetails ud ON cpu.UserId=ud.AuthUserId JOIN Users u ON cpu.UserId=u.Id JOIN Comments c ON cpu.CommentId=c.Id WHERE PostId=@postId";
                var data = await connection.QueryAsync<CommentWithUserandPostDTO>(query, new
                {
                    @postId = postId
                });
                return data;
            }
        }
    }
}
