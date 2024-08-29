using Application_Layer.Service_Interface;
using Dapper;
using Domain_Layer.Data_Access;
using Domain_Layer.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string connectionstring;
        private readonly ApplicationDbContext appDbContext;

        public EmployeeService(IConfiguration config,ApplicationDbContext _appDbContext)
        {
            connectionstring = config.GetConnectionString("DefaultConnection");
            appDbContext = _appDbContext;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetEmployee()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT Name,Department FROM Employees";
                var data = await connection.QueryAsync<EmployeeDTO>(query);
                return data.ToList();
            }
        }

        public async Task AddEmployee(EmployeeDTO emp)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Employees(Name,Department) VALUES(@Name,@Department)";
                await connection.ExecuteAsync(query, new
                {
                    @Name = emp.Name,
                    @Department = emp.Department
                    
                });
            }
        }
    }
}
