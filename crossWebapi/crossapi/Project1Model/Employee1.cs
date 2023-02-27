using System;
using System.Collections.Generic;

namespace Project1Model;

public partial class Employee1
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int EmpSalary { get; set; }

    public int DeptId { get; set; }

    public virtual Department1 Dept { get; set; } = null!;
}
