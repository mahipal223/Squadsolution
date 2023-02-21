using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment1.Models
{
    public class EmployeeDto
    {

        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public int Salary { get; set; }

    }
}