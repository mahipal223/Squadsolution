using System;
using System.Collections.Generic;

namespace Assignment4.Models
{
    public partial class Designation1
    {
        public Designation1()
        {
            Employee1s = new HashSet<Employee1>();
        }

        public int DesId { get; set; }
        public string? DesName { get; set; }

        public virtual ICollection<Employee1> Employee1s { get; set; }
    }
}
