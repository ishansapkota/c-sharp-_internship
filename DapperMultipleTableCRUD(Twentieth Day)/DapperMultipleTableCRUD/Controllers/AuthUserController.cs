using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperMultipleTableCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IUserService iService;

        public AuthUserController(IUserService _iService)
        {
            iService = _iService;
        }

        [HttpPost("user-register")]
        public IActionResult RegisterUser(UserDTO user)
        {
            iService.AddUser(user);
            return Ok("The user has been successfully added to the database!");
        }
    }
}
