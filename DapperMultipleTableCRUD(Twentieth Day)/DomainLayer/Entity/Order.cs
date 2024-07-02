using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderDate { get; set; } = string.Empty;
        
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Products { get; set; }
    }
}
