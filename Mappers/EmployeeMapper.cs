using task1.Mappers;
using task1.Dtos.EmployeeDtos;
using task1.Models;
using task1.Controllers;


namespace task1.Mappers
{
    public static class EmployeeMappers
    {
        public static Employee ToEmployeeFromAddDto(this AddEmployeeDto empDto)
        {
            return new Employee
            {
                EmployeeName = empDto.EmployeeName,
                Email = empDto.Email,
                DepartmentId = empDto.DepartmentId,
                Salary = empDto.Salary,
                MobileNo = empDto.MobileNo
            };

        }
    }
}
