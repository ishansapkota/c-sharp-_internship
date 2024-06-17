using System.ComponentModel.DataAnnotations;

namespace CRUD_Registration_Login.Models
{
    public class Goods
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

    }
}
