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
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionstring;

        public ProductRepository(IConfiguration _configuration)
        {
            connectionstring= _configuration.GetConnectionString("DefaultConnection");
        }
        public void Add(ProductDTO product)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Products(ProductName,ProductPrice) VALUES (@ProductName,@ProductPrice)";
                connection.Execute(query,product);
            }
        }
    }
}
