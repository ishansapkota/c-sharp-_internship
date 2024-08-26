using Application_Layer.Service_Interface;
using Domain_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok("hey");
        }
/*
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO emp)
        {
            await iEmp.AddEmployee(emp);
            return Ok();
        }*/
    }
}
