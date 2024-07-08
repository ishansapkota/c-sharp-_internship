using Dapper;
using DomainLayer.DTO;
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
                var query = "INSERT INTO Products(Id,ProductName,ProductPrice) VALUES (@Id,@ProductName,@ProductPrice)";
                connection.Execute(query, product);
            }
        }

        public IEnumerable<ProductDTO> Get()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * FROM Products";
                var data = connection.Query<ProductDTO>(query);
                return data.ToList();
            }
        }

        public ProductDTO GetById(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT * from Products WHERE Id=@Id";
                var data = connection.QueryFirstOrDefault<ProductDTO>(query, new
                {
                    @Id = id
                });
                return data;
                
            }
        }

        public void Update(ProductDTO product)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "UPDATE Products SET Id=@Id,ProductName=@ProductName,ProductPrice=@ProductPrice WHERE Id=@Id";
                connection.Execute(query, product);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "DELETE FROM Products WHERE Id=@Id";
                connection.Execute(query, new
                {
                    @Id = id
                });
            }
        }
    }
}
