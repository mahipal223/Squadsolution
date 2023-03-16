using System;
using System.Collections.Generic;

namespace ProjectDemoWeb.Data;

public partial class EmployeeFullName
{
    public int EmployeeNoId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? EmpId { get; set; }

    public  EmployeeMain Emp { get; set; }
}
