using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface ICommentRepository
    {

        Task PostAsync(CommentDTO comment,int userId,int postId);

        Task<IEnumerable<CommentWithUserandPostDTO>> GetByUserAsync(int userId);

        Task<IEnumerable<CommentWithUserandPostDTO>> GetByPostAsync(int  postId);
       

    }
}
