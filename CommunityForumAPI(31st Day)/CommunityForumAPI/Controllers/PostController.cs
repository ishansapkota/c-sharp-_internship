using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("post/{id}"),Authorize(Roles ="User")]

        public async Task<IActionResult> PostAdd(PostDTO post,int id)
        {
            try
            {
                var response = await iService.AddPostAsync(post, id);
                return Ok(new { message = $"{response}" });
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("posts")]
        public async Task<IEnumerable<PostWithUserDTO>> GetAllPostsAsync()
        {
            
                var data = await iService.GetAllPostAsync();
            return (IEnumerable<PostWithUserDTO>)Ok(data);
            

            
        }
            

    }
}
