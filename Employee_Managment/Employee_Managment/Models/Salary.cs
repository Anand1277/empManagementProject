using System;
using System.Collections.Generic;

namespace Employee_Managment.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int EmployeeId { get; set; }

    public decimal Amount { get; set; }

    public DateTime EffectiveDate { get; set; }
}
