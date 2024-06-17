using CRUD_Registration_Login.Data;
using CRUD_Registration_Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Registration_Login.Controllers
{
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GoodsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("AddGoods");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGoodsDTO add)
        {
            var goods = new Goods
            {
                Name = add.Name,
                Description = add.Description
            };

            await applicationDbContext.Goods.AddAsync(goods);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");

         }
    }
}
