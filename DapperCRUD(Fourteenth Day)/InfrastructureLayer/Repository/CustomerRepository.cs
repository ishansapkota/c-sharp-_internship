using Dapper;
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
    public class CustomerRepository : IRepository<Customer>
    {

        private readonly string _connectionstring;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionstring);
            var query = "SELCT * FROM Customer";
            var customer = await connection.QueryAsync<Customer>(query);
            return customer.ToList();
        }

        public async Task AddAsync(Customer c)
        {
            using var connection = new SqlConnection(_connectionstring);
            var query = "INSERT INTO Customer(Name,Phone,Email,Address) VALUES(@Name,@Phone,@Email,@Address)";
            var customer = await connection.ExecuteAsync(query, c);
        }

        public async Task UpdateAsync(Customer c)
        {
            using var connection = new SqlConnection(_connectionstring);
            var query = "UPDATE Customer SET Name=@Name, Phone=@Phone, Email=@Email, Address=@Address";
            var customer = await connection.ExecuteAsync(query, c);
        }

        public async Task DeleteAsync(Customer c)
        {
            using var connection = new SqlConnection(_connectionstring);
            var query = "DELETE FROM Customer WHERE ID=@ID";
        }

    }
}
