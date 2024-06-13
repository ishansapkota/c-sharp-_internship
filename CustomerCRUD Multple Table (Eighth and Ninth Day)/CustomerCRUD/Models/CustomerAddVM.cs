using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class CustomerAddVM
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string email { get; set; } = " ";

        [Required]
        public string name { get; set; } = "";

        [Required]
        public string phone { get; set; } = "";

        public string address { get; set; } = "";

        [Required]
        public DateTime doB { get; set; }

       
        public int GoodsID {  get; set; }   

        [Required]
        public string GoodsName { get; set; } = " ";
    }
}
