using System.ComponentModel.DataAnnotations;

namespace CRUD_Registration_Login.Models
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
