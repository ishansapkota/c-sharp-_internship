using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface ICommentService
    {
        Task PostCommentAsync(CommentDTO comment, int userId, int postId);

        Task<IEnumerable<CommentWithUserandPostDTO>> GetCommentsByUserAsync(int userId);

        Task<IEnumerable<CommentWithUserandPostDTO>> GetCommentsByPostAsync(int postId);
    }
}
