using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class CommentWithUserandPostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommentMessage { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }

    }
}
