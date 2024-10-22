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
    public class EmployeesController : ControllerBase
    {
        public readonly Task1Context context;

        public EmployeesController(Task1Context _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await context.Employees.FromSqlRaw("exec GetEmployees").ToListAsync();

            if (employees == null || !employees.Any())
                return NotFound();

            return Ok(employees);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var emp = await context.Employees.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto empDto)
        {

            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            await context.Database.ExecuteSqlRawAsync("exec EditEmployee @id, @name, @dep, @salary, @email, @mob, @date ",
                    new SqlParameter("@id", id),
                    new SqlParameter("@name", empDto.EmployeeName),
                    new SqlParameter("@dep", empDto.DepartmentId),
                    new SqlParameter("@salary", empDto.Salary),
                    new SqlParameter("@email", empDto.Email),
                    new SqlParameter("@mob", empDto.MobileNo),
                    new SqlParameter("@date", empDto.JoiningDate));

            var emp = await context.Employees.FindAsync(id);
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDto employeeDto)
        {
            var emp = employeeDto.ToEmployeeFromAddDto();

            await context.Database.ExecuteSqlRawAsync("exec AddEmployee @name, @dep, @salary, @email, @mob",
                    new SqlParameter("@name", employeeDto.EmployeeName),
                    new SqlParameter("@dep", employeeDto.DepartmentId),
                    new SqlParameter("@salary", employeeDto.Salary),
                    new SqlParameter("@email", employeeDto.Email),
                    new SqlParameter("@mob", employeeDto.MobileNo),
                    new SqlParameter("@date", employeeDto.JoiningDate));

            return CreatedAtAction(nameof(GetAll), emp);
        }
    }
}
