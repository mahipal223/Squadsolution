using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment1.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }  
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}