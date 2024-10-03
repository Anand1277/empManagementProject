using System;
using System.Collections.Generic;

namespace Employee_Managment.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime HireDate { get; set; }

    public string? JobTitle { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
