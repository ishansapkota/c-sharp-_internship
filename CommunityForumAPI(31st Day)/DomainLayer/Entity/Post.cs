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

        public int AuthUserId { get; set; }

        public bool IsApproved { get; set; }

        [ForeignKey("AuthUserId")]
        public AuthUser AuthUsers { get; set; }

    }
}
