using Application_Layer.Service_Interface;
using Dapper;
using Domain_Layer.DTOs;
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
        /*private readonly string connectionstring;

        public EmployeeService(IConfiguration config)
        {
            connectionstring = config.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<EmployeeDTO>> GetEmployee()
        {
            using (var connection = new NpgsqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Employees";
                var data = await connection.QueryAsync<EmployeeDTO>(query);
                return data.ToList();
            }
        }

        public async Task AddEmployee(EmployeeDTO emp)
        {
            using (var connection = new NpgsqlConnection(connectionstring))
            {
                var query = "INSERT INTO Employees(Name,Department) VALUES(@Name,@Department)";
                await connection.ExecuteAsync(query, emp);
            }
        }*/
    }
}
