using System;
using System.Collections.Generic;

namespace Assignment4.Models
{
    public partial class Employee1
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public int DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        public string? HaveKnow { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? ReportingPerson { get; set; }
        public bool? IsActive { get; set; }

        public virtual Department1? Department { get; set; }
        public virtual Designation1 Designation { get; set; } = null!;
    }
}
