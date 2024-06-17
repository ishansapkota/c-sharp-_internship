using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRUD.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter the email")]
        public string Email { get; set; } = " ";

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        [BindProperty]
        public string Address { get; set; } = "";

        [Required]       
        public DateTime DoB { get; set; }

    }
}
