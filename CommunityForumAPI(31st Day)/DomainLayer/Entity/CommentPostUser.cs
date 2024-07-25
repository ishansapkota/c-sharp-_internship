using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class CommentPostUser
    {
        [Key]
        public int Id { get; set; }

        public int CommentId { get; set; }
        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
