using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public AuthController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        private static User user = new User();
        private readonly IConfiguration configuration;

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDTO userdto)
        {
            user.Email = userdto.Email;
            HashPassword(userdto.Password, out byte[] PassHash, out byte[] PassSalt);
            user.PasswordSalt = PassSalt;
            user.PasswordHash = PassHash;
            return Ok(user);
        }

        private void HashPassword(string password,out byte[] passHash, out byte[] passSalt)
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
            if(user.Email!=userDTO.Email)
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
                new Claim("email",user.Email)
            };

            var jwtToken = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddDays(30),
                    signingCredentials: new SigningCredentials
                    (
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"])),SecurityAlgorithms.HmacSha512Signature)
                    );
            var jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return jwt;
        }
    } 
}
