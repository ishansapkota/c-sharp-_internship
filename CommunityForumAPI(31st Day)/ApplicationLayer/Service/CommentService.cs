using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository iRepo;

        public CommentService(ICommentRepository _iRepo)
        {
            iRepo = _iRepo;
        }

        public async Task PostCommentAsync(CommentDTO comment, int userId, int postId)
        {
            await iRepo.PostAsync(comment, userId, postId);
        }

        public async Task<IEnumerable<CommentWithUserandPostDTO>> GetCommentsByUserAsync(int userId)
        {
            var data  = await iRepo.GetByUserAsync(userId);
            return data;
        }

        public async Task<IEnumerable<CommentWithUserandPostDTO>> GetCommentsByPostAsync(int postId)
        {
            var data = await iRepo.GetByPostAsync(postId);
            return data;
        }

        public async Task DeleteCommentsByUserAsync(int id, int userId)
        {
            await iRepo.DeleteCommentsAsync(id, userId);
        }

    }
}
