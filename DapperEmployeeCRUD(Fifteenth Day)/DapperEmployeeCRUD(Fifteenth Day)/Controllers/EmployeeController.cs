using ApplicationLayer.Service_Interface;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperEmployeeCRUD_Fifteenth_Day_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService<Employee> _iService;

        public EmployeeController(IEmployeeService<Employee> iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var data = await _iService.GetAllEmployeeAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            await _iService.AddEmployeeAsync(emp);
            return Ok("Employee has been added");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var data = await _iService.GetEmployeeById(id);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var data = await _iService.GetEmployeeById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee emp)
        {
            await _iService.UpdateEmployeeAsync(emp);
            return Ok("Data has been updated");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
    
            await _iService.DeleteEmployeeAsync(id);
            return Ok("The data has been deleted!");
        }
    }
}
