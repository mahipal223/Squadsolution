using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment4.ViewModel
{
    public class EmplyeeViewModel
    {
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        public string? HaveKnow { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }

        public DateTime? JoiningDate1 { get; set; }
        public string? ReportingPerson { get; set; }
        public bool? IsActive { get; set; }

        public IList<SelectListItem> HaveKnowleadeof { get; set; }

        public virtual Department1? Department { get; set; }
        public virtual Designation1? Designation { get; set; }
    }
}