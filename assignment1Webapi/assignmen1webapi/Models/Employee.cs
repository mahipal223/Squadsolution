using System;
using System.Collections.Generic;

namespace assignmen1webapi.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int DepId { get; set; }

    public int Salary { get; set; }

    public virtual Department Dep { get; set; } = null!;
}
