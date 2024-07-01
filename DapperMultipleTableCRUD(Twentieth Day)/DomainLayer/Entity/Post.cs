using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string PostTitle { get; set; } = string.Empty;

        public string PostDescription { get; set; } = string.Empty;

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; }
    }
}
