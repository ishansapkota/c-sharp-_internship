using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserDTO user)
        {
            try
            {
                await service.RegisterUserAsync(user);
                return Ok(new { message = "New user has been registered!" });
            }

            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> KYC(EditUserDTO user)
        {
            try
            {
                await service.UpdateUserAsync(user);
                return Ok(new { message = "The data has been updated!" });
            }

            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
