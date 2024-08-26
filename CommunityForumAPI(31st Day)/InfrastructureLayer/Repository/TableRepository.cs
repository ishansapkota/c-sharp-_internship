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
    public class TableRepository:ITableRepository
    {
        private readonly string connectionstring;

        public TableRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(TeamDTO team)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Teams(TeamName,Points) VALUES (@TeamName,@Points)";
                await connection.ExecuteAsync(query, team);
            }
        }

        public async Task UpdateAsync(int id,TeamDTO team)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "UPDATE Teams SET Points=@Points, GoalDifference = @GoalDifference WHERE Id=@Id";
                await connection.ExecuteAsync(query, new
                {
                    @Points = team.Points,
                    @GoalDifference = team.GoalDifference,
                    @Id = id
                });
            }
        }

        public async Task<IEnumerable<TeamDTO>> GetAllAsync()
        {
            using(var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Teams";
                var data = await connection.QueryAsync<TeamDTO>(query);
                return data.ToList();
            }
        }

        public async Task<TeamDTO> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Teams WHERE Id=@Id";
                var data = await connection.QueryFirstOrDefaultAsync<TeamDTO>(query, new
                {
                    @Id = id
                });
                return data;
            }
        }

        public async Task<IEnumerable<TeamDTO>> GetAllOrderAsync()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Teams ORDER BY Points DESC,GoalDifference DESC, TeamName ASC";
                var data = await connection.QueryAsync<TeamDTO>(query);
                return data.ToList();
            }
        }
    }
}
