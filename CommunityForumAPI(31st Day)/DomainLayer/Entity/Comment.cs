using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string CommentMessage { get; set; } = string.Empty;

    }
}
