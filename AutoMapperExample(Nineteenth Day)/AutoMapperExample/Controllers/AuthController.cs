using AutoMapper;
using AutoMapperExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;

        public AuthController(IMapper _mapper)
        {
            mapper = _mapper;
        }
        [HttpPost]
        public IActionResult CreateUser(UserDTO userdto)
        {
            var user = mapper.Map<User>(userdto);

            return Ok(user);

        }


    }
}
