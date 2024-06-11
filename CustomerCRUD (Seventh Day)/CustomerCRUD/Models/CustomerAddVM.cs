using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class CustomerAddVM
    {
        [Required]
        public string email { get; set; } = " ";

        [Required]
        public string name { get; set; } = "";

        [Required]
        public string phone { get; set; } = "";

        public string address { get; set; } = "";

        [Required]
        public DateTime doB { get; set; }
    }
}
