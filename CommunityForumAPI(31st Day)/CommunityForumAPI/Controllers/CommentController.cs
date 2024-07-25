using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CommunityForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService iService;

        public CommentController(ICommentService _iService)
        {
            iService = _iService;
        }

        [HttpPost("{postId}"),Authorize(Roles ="User")]
        public async Task<IActionResult> CommentPostingAsync(CommentDTO comment,int postId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.SerialNumber).Value;
                await iService.PostCommentAsync(comment, Convert.ToInt16(userId), postId);
                return Ok();
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("comments-by-user"),Authorize(Roles ="User")]
        public async Task<IActionResult> GetAllCommentsByUser()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.SerialNumber);
                var data = await iService.GetCommentsByUserAsync(Convert.ToInt16(userId));
                return Ok(data);
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


       [HttpGet, Route("comments-by-post/{postId}")]
        public async Task<IActionResult> GetAllCommentsByPost(int postId)
        {
            var data = await iService.GetCommentsByPostAsync(postId);
            return Ok(data);
        }
    }
}
