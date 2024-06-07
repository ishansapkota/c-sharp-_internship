using System.ComponentModel.DataAnnotations;

namespace CRUD2.Models
{
    public class AddUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
