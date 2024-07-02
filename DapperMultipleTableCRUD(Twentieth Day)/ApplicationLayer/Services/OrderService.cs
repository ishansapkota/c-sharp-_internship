using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository iOrderRepo;

        public OrderService(IOrderRepository _iOrderRepo)
        {
            iOrderRepo = _iOrderRepo;
        }
        public void AddOrder(OrderDTO order)
        {
            iOrderRepo.Add(order);
        }

        public IEnumerable<OrderViewDTO> ViewOrder()
        {
            var data = iOrderRepo.View();
            return data;
        }
    }
}
