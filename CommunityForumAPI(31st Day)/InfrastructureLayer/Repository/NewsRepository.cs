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
    public class NewsRepository:INewsRepository
    {
        private readonly string connectionstring;

        public NewsRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(NewsDTO news)
        {
            using(var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO News(NewsTitle,NewsDescription) VALUES (@NewsTitle,@NewsDescription)";
                await connection.ExecuteAsync(query,news);
            }
        }

        public async Task<IEnumerable<NewsDTO>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT Id,NewsTitle,NewsDescription FROM News";
                var news = await connection.QueryAsync<NewsDTO>(query);
                return news.ToList();
            }
        }
    }
}
