using CRUD_Registration_Login.Data;
using CRUD_Registration_Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Registration_Login.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext applicationDBContext;

        public UserController(ApplicationDbContext  applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO reg)
        {
            var user = new User
            {
                Email = reg.Email,
                Password = reg.Password,
            };
            await applicationDBContext.Users.AddAsync(user);
            await applicationDBContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO log)
        {
            var user = await applicationDBContext.Users.FirstOrDefaultAsync(x=>x.Email==log.Email);
      
            if(user != null&& user.Password==log.Password)
            {
                HttpContext.Session.SetInt32("UserID", user.ID);
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(log);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
