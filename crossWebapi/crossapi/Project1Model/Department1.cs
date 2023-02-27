using System;
using System.Collections.Generic;

namespace Project1Model;

public partial class Department1
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee1> Employee1s { get; } = new List<Employee1>();
}
