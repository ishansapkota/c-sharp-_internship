using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Three_Tier_Architecture_CRUD_Tenth_and_Eleventh_Day_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Service service;

        public EmployeeController(Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            if (emp != null)
            {
                service.CreateEmployee(emp);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
