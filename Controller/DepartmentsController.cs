using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;
using task1.Dtos.EmployeeDtos;
using task1.Mappers;
using Microsoft.Data.SqlClient;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //dbcontext
        public readonly Task1Context context;
         
        //constructor
        public DepartmentsController(Task1Context _context)
        {
            context = _context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await context.Departments.ToListAsync();
            return Ok(departments); 
        }

    }
}
