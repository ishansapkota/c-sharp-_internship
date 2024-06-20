using BusinessLogicLayer.Service;
using DataAccessLayer.EntitiesOrModel;
using Microsoft.AspNetCore.Mvc;

namespace ThreeTierPrac.Controllers
{
    public class JournalController : Controller
    {
        private readonly IService<Journal> _service;

        public JournalController(IService<Journal> service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AddJournal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJournal(Journal j)
        {
            _service.CreateWorkData(j);
            return RedirectToAction("Index","Home");
        }

        public IActionResult ListJournal()
        {
            var list = _service.ListWorkData();
            return View(list);
        }

    }
}
