using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperMultipleTableCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService iProductService;

        public ProductController(IProductService _iProductService)
        {
            iProductService = _iProductService;
        }

        [HttpPost("add-product")]
        public IActionResult ProductAdd(ProductDTO product)
        {
            try
            {
                iProductService.AddProduct(product);
                return Ok("The product has been added to the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
