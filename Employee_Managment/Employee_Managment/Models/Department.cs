using System;
using System.Collections.Generic;

namespace Employee_Managment.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int? ManagerId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
