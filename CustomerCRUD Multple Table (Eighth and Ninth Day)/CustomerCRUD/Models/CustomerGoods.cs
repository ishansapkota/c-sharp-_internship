using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRUD.Models
{
    public class CustomerGoods
    {
        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public int GoodsID { get; set; }

        [ForeignKey("GoodsID")]
        public Goods Goods { get; set; } 
    }
}
