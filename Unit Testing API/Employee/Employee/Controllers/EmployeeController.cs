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
        private readonly IEmployeeService iEmp;

        public EmployeeController(IEmployeeService _iEmp)
        {
            iEmp = _iEmp;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await iEmp.GetEmployee();
           
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO emp)
        {
            await iEmp.AddEmployee(emp);
            return Ok();
        }


    }
}
