using Dapper;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connectionstring;

        public OrderRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public void Add(OrderDTO order)
        {
            using(var connection = new SqlConnection(connectionstring))
            {
                var query = "INSERT INTO Orders(OrderDate,ProductId) VALUES (@OrderDate,@ProductId)";
                connection.Execute(query, order);
            }
        }

        public IEnumerable<OrderViewDTO> View()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var query = "SELECT o.OrderId , p.ProductName , p.ProductPrice, o.OrderDate FROM Orders as o LEFT JOIN Products as p ON o.ProductId = p.Id";
                var data  = connection.Query<OrderViewDTO>(query);
                return data;
            }
        }
    }
}
