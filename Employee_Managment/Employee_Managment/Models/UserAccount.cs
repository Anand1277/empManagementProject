using System;
using System.Collections.Generic;

namespace Employee_Managment.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string PasswordHash { get; set; } = null!;
}
