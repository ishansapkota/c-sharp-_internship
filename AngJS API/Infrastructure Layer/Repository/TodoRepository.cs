using Dapper;
using Domain_Layer.Models;
using Domain_Layer.Repository_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repository
{
    public class TodoRepository : IRepository<ToDo>
    {
        private readonly string connectionstring;

        public TodoRepository(IConfiguration _configuration)
        {
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ToDo>> GetTodosAsync()
        {
            /*using (var connection = new SqlConnection(connectionstring))
            {
                await connection.BeginTransactionAsync();
                var query = "SELECT * FROM todos";

                var todo = await connection.QueryAsync(query);
            }*/
            using(var connection = new SqlConnection(connectionstring))
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendFormat(@"SELECT * FROM todos");
                var todos = await connection.QueryAsync<ToDo>(strSQL.ToString());
                return todos;
            }
            
        }

        public async Task AddTodoAsync(ToDo todo)
        {
            using(var connection = new SqlConnection(connectionstring))
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendFormat(@"INSERT INTO todos VALUES(@Name,@Urgency)");
                DynamicParameters dy = new DynamicParameters();
                dy.Add("@Name", todo.Name);
                dy.Add("@Urgency", todo.Urgency);
                await connection.ExecuteAsync(strSQL.ToString(), dy);
            }
        }

        /*
        public Task<ToDo> GetTodoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
        public Task UpdateTodoAsync(ToDo todo)
        {
            throw new NotImplementedException();
        }*/
    }
}
