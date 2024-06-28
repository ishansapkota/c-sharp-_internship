using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LoginSignupAPIusingJWT_Seventeenth_day_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public AuthController(IConfiguration _configuration,IMapper _mapper)
        {
            configuration = _configuration;
            mapper = _mapper;
        }

        public static User admin = new User()
        {
            Email = "admin@gmail.com",
            Roles = "Admin"
        };

        static AuthController()
         {
            HashPassword("admin@123", out byte[] PassHash, out byte[] PassSalt);
            admin.PasswordSalt = PassSalt;
            admin.PasswordHash = PassHash;
        }

        private static User user = new User();
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        [HttpPost("register/user")]
        public async Task<IActionResult> CreateUser(UserDTO userdto)
        {
            HashPassword(userdto.Password, out byte[] PassHash, out byte[] PassSalt);
            var map = mapper.Map<User>(userdto);

            map.PasswordHash = PassHash;
            map.PasswordSalt = PassSalt;
            map.Roles = "User";
            return Ok(map);

            /*user.Email = userdto.Email;
            HashPassword(userdto.Password, out byte[] PassHash, out byte[] PassSalt);
            user.PasswordSalt = PassSalt;
            user.PasswordHash = PassHash;
            user.Roles = "User";
            return Ok(user);
             */
            

        }

        /*[HttpPost("register/admin")]
        public async Task<IActionResult> CreateAdmin(UserDTO userdto)
        {
            user.Email = userdto.Email;
            HashPassword(userdto.Password, out byte[] PassHash, out byte[] PassSalt);
            user.PasswordSalt = PassSalt;
            user.PasswordHash = PassHash;
            user.Roles = "Admin";
            return Ok(user);
        }
*/

        private static void HashPassword(string password,out byte[] passHash, out byte[] passSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser(UserDTO userDTO)
        {
            if(admin.Email == userDTO.Email)
            {
                if (!CheckPassword(userDTO.Password, admin.PasswordHash, admin.PasswordSalt))
                {
                    return BadRequest("Admin passwords do not match");
                }
                var admin_token = GenerateToken(admin);
                return Ok(admin_token);
            }

            if (user.Email != userDTO.Email)
            {
                return BadRequest("User not found");
            }
            if (!CheckPassword(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Passwords donot match"); 
            }

            var token = GenerateToken(user);
            return Ok(token);  
        }

        private bool CheckPassword(string password, byte[] passHash, byte[] passSalt)
        {
            using(var hmac = new HMACSHA512(passSalt))
            {
                var computedPass = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedPass.SequenceEqual(passHash);
                
            }
        }

        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Email",user.Email),
                new Claim(ClaimTypes.Role,user.Roles)
            };

           /* var roles = user.Roles.Split(',');
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }*/

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]));

            var jwtToken = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddDays(30),
                    signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature));
            var jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return jwt;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("checkapiua")]
        public IActionResult CheckingApi()
        {
            return Ok("Both admin and user can see this!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("checkapia")]
        public IActionResult CheckingApiA()
        {
            return Ok("admin can see this!");
        }

        [Authorize(Roles = "User")]
        [HttpGet("checkapiu")]
        public IActionResult CheckingApiU()
        {
            return Ok("user can see this!");
        }


    }
}
