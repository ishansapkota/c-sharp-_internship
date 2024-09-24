using Domain_Layer.Data_Access;
using Domain_Layer.Models;
using Domain_Layer.Repository_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngJS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<ToDo> repo;
        private readonly string connectionstring;

        public ToDoController(ApplicationDbContext _context,IRepository<ToDo> _repo)
        {
            context = _context;
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todo = await repo.GetTodosAsync();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodos(ToDo todo)
        {
            await repo.AddTodoAsync(todo);
            return Ok(new { message = "The data has been added!" });
        }

    }
}
