using BusinessLogicLayer.Service;
using DataAccessLayer.EntitiesOrModel;
using Microsoft.AspNetCore.Mvc;

namespace ThreeTierPrac.Controllers
{
    public class WorkController : Controller
    {
        private readonly IService<Work> _service;

        public WorkController(IService<Work> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult AddWork()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddWork(Work work)
        { 
            _service.CreateWorkData(work);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ListWork()
        {
            var detail = _service.ListWorkData();
            return View(detail);
        }

        [HttpGet]
        public IActionResult UpdateWork(int id)
        {
            var user = _service.GetWorkByDay(id);
            if (user==null)
            {
                return NotFound();
            }
            return View(user);

        }

        [HttpPost]
        public IActionResult UpdateWork(Work work)
        {
            _service.UpdateWorkData(work);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DeleteWork(int id)
        {
            _service.DeleteWorkData(id);
            return RedirectToAction("ListWork");
        }

        public IActionResult ViewWork (int id)
        {
            var data = _service.GetWorkByDay(id);
            return View(data);
        }
    }
}
