using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class UpdateCustomerVM
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; } = " ";

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

        [Required]
        public DateTime DoB { get; set; }
    }
}
