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
    public class PostRepository : IPostRepository
    {
        private readonly string connectionstring;

        public PostRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<string> Add(PostDTO post,int id)
        {
            using(var connection = new SqlConnection(connectionstring))
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
    }
}
