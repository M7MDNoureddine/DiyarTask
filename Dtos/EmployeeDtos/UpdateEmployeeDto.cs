namespace task1.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public string EmployeeName { get; set; } = null!;

        public int DepartmentId { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public DateOnly? JoiningDate { get; set; }
    }
}
