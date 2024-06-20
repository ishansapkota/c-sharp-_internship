using BusinessLogicLayer_Services_.Service;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ShopCRUD_Thirteenth_Day_.Controllers
{
    public class ShopController : Controller
    {
        private readonly IService<Shop> _service;

        public ShopController(IService<Shop> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var list = _service.GetAllData();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddShop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddShop(Shop s)
        {
            _service.AddData(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditShop(int id)
        {
            var shop = _service.GetDataByID(id);
            return View(shop);
        }

        [HttpPost]
        public IActionResult EditShop(Shop s)
        {
            _service.UpdateData(s);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteShop(int id)
        {
            var shop = _service.GetDataByID(id);
            _service.DeleteData(shop);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var shop = _service.GetDataByID(id);
            return View(shop);
        }
    }

}
