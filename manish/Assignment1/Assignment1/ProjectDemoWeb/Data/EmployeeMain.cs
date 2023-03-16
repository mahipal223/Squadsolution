using System;
using System.Collections.Generic;

namespace ProjectDemoWeb.Data;

public partial class EmployeeMain
{
    public int EmpId { get; set; }

    public long? ContectNo { get; set; }

    public string? CompanyLocation { get; set; }

    public string? Address { get; set; }

    public  ICollection<EmployeeFullName> EmployeeFullNames { get; } = new List<EmployeeFullName>();
}
