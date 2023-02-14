using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment1.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(25)]
        public string EmpName { get; set; }
        [ForeignKey("Departments")]
        public int DepId { get; set; }

        public virtual Department Departments { get; set; }
        public int Salary { get; set; }

    }
}