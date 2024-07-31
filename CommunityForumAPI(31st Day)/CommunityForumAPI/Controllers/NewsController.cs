using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService iService;

        public NewsController(INewsService _iService)
        {
            iService = _iService;
        }

        [HttpPost,Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddNewsAsync(NewsDTO news)
        {
            try
            {
                await iService.AddNewsAsync(news);
                return Ok(new { message = "News Posted" });
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNewsAsync()
        {
            try
            {
                var news = await iService.GetAllNewsAsync();
                return Ok(news);
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-news/{id}"), Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            try
            {
                await iService.DeleteNewsAsync(id);
                return Ok(new { message = "The news has been deleted" });
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
