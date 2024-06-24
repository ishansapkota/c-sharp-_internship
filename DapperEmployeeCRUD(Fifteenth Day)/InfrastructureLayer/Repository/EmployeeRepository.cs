using Dapper;
using DomainLayer.Entity;
using DomainLayer.Repo_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly string _connectionstring;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionstring= configuration.GetConnectionString("DefaultConnection");
        }
    
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using(var connection = new SqlConnection(_connectionstring))
            {
                var query = "SELECT * FROM Employee";
                var emp =  await connection.QueryAsync<Employee>(query);
                return emp.ToList();
            }
           
        }

        public async Task UpdateAsync(Employee t)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var query = "UPDATE Employee SET Name=@Name,Age=@Age,Email=@Email,Address=@Address where Id=@Id";
                await connection.ExecuteAsync(query, t);
            }
        }

        public async Task AddAsync(Employee t)
        {
            using(var connection = new SqlConnection(_connectionstring))
            {
                var query = "INSERT INTO Employee(Id,Name,Age,Email,Address) VALUES (@Id,@Name,@Age,@Email,@Address)";
                var data = await connection.ExecuteAsync(query,t);
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var query = "SELECT * FROM Employee WHERE Id=@Id";
                var data = await connection.QueryFirstOrDefaultAsync(query, new { @Id = id });
                
                return data as Employee;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var query = "DELETE FROM Employee WHERE Id=@Id";
                await connection.ExecuteAsync(query,new { Id = id });
            }
        }

    }
}
