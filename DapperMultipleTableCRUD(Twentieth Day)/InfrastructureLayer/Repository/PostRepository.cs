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
        /*private readonly string _connectionstring;

        public PostRepository(IConfiguration configuration)
        {
            _connectionstring  = configuration.GetConnectionString("DefaultConnection");
        }
        public void Add(PostDTO post)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var query = "INSERT INTO Posts(PostTitle,PostDescription) VALUES (@PostTitle,@PostDescription)";
                connection.Execute(query, new
                {

                });
            }
        }*/
        public void Add(PostDTO post)
        {
            throw new NotImplementedException();
        }
    }
}
