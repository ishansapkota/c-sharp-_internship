using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int ProductPrice { get; set; }


    }
}
