using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("register-user")]
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

        [HttpPut,Authorize(Roles ="User")]
        public async Task<IActionResult> KYC(EditUserDTO user)
        {
            try
            {
                await service.UpdateUserAsync(user);
                return Ok(new { message = "The data has been updated!"});
            }
            
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserById(int id)
        {
            try
            {
                var data = await service.GetUserByIdAsync(id);
                return Ok(new { message = data });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserDTO user)
        {
            try
            {
                var result = await service.LoginUserAsync(user);
                return Ok(new { result} );
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        /*[HttpPost]
        public async Task<IActionResult> UserLogin(UserDTO user)
        {
            try
            {
                var loggedin = await service.LoginUserAsync(user);
                if (loggedin)
                {
                    return Ok(new { message = "User has logged in" });
                }
                else
                {
                    return BadRequest(new { message = "User log-in failed" });
                }
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
    }
}
