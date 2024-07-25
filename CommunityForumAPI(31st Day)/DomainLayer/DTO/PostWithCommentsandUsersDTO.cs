using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class PostWithCommentsandUsersDTO
    {
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string UserName { get; set; }
        public ICollection<CommentWithUserDTO> CommentsandUsers { get; set; }
    }
}
