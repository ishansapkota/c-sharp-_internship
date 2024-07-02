using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperMultipleTableCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService iOrderService;

        public OrderController(IOrderService _iOrderService)
        {
            iOrderService = _iOrderService;
        }

        [HttpPost("add-order")]
        public IActionResult OrderAdd(OrderDTO order)
        {
            try
            {
                iOrderService.AddOrder(order);
                return Ok("The order has been placed");
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("view-order")]
        public IActionResult OrderView()
        {
            var data = iOrderService.ViewOrder();
            return Ok(data);
        }


    }
}
