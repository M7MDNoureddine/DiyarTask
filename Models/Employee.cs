using System;
using System.Collections.Generic;

namespace task1.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public DateOnly? JoiningDate { get; set; }

    public virtual Department Department { get; set; } = null!;
}
