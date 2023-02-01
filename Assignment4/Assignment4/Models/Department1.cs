using System;
using System.Collections.Generic;

namespace Assignment4.Models
{
    public partial class Department1
    {
        public Department1()
        {
            Employee1s = new HashSet<Employee1>();
        }

        public int DepId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<Employee1> Employee1s { get; set; }
    }
}
