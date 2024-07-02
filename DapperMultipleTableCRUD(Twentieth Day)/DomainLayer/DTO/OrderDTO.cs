using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string OrderDate { get; set; } = string.Empty;

        public int ProductId { get; set; }
    }
}
