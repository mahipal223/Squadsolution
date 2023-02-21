using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignmen1webapi.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;
    [ForeignKey("Dep")]
    public int DepId { get; set; }

    public int Salary { get; set; }

    public virtual Department Dep { get; set; } = null!;
}
