using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entity;
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
                return Ok(new { message = "The product has been added to the database" });
                /*return Ok();*/
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-products")]
        public IActionResult ProductGet()
        {
            try
            {
                var data = iProductService.GetProduct();
                return Ok(data);
            }

            catch (Exception e)
            {
                {
                    return BadRequest(e.Message);
                }
            }

        }

        [HttpGet("list-product/{id}")]
        public IActionResult ProductGetById(int id)
        {
            try
            {
                var data = iProductService.GetProductById(id);
                return Ok(data);
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-product")]
        public IActionResult ProductUpdate(ProductDTO product)
        {
            try
            { 
                iProductService.UpdateProduct(product);
                return Ok(new {  message="Data has been updated successfully!"});
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult ProductDelete(int id)
        {
            try
            {
                iProductService.DeleteProduct(id);
                return Ok();
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
