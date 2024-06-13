using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRUD.Models
{
    public class Goods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodsID { get; set; }

        public string GoodsName { get; set; } = " ";
    }
}
