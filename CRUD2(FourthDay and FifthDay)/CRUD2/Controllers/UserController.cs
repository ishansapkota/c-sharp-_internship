using CRUD2.Data;
using CRUD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddUserViewModel adduser)
        {
            var user = new User
            {
                Username = adduser.Username,
                Password = adduser.Password
            };

            await applicationDbContext.Users.AddAsync(user);
            await applicationDbContext.SaveChangesAsync();
            return View("Register");
        }

    }
}
