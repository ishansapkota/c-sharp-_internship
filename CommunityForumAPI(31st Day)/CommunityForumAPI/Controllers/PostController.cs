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
    public class PostController : ControllerBase
    {
        private readonly IPostService iService;

        public PostController(IPostService _iService)
        {
            iService = _iService;
        }

        [HttpPost("post/"),Authorize(Roles ="User")]

        public async Task<IActionResult> PostAdd(PostDTO post)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.SerialNumber).Value;
                if (id == null)
                {
                    return Unauthorized("User Id is missing from token");
                }
                else
                {
                    var response = await iService.AddPostAsync(post, Convert.ToInt16(id));
                    return Ok(new { message = $"{response}" });
                }
                
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            
                var data = await iService.GetAllPostAsync();
                return  Ok(data);
        }

        [HttpGet("unapproved-posts"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUnapprovedPostsAsync()
        {
            var data = await iService.GetAllUnapprovedPostAsync();
            return Ok(data);
        }

        [HttpGet("approve/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovePosts(int id)
        {

            await iService.ApprovePost(id);
            return Ok();
        }

        [HttpGet("delete-post/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePosts(int id)
        {
            await iService.DeletePost(id);
            return Ok();
        }

        [HttpGet("user-post"),Authorize(Roles ="User")]
        public async Task<IActionResult> RetrieveUserPosts()
        {
            var id = User.FindFirst(ClaimTypes.SerialNumber).Value;
            var data = await iService.RetrievePostByUser(Convert.ToInt16(id));
            return Ok(data);
        }
    }
}
