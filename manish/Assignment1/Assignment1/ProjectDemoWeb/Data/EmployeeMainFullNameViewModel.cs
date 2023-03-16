using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemoWeb.Data
{
    public class EmployeeMainFullNameViewModel
    {
     

    public long? ContectNo { get; set; }

    public string? CompanyLocation { get; set; }

    public string? Address { get; set; }
    // public string? FirstName { get; set; }

    // public string? LastName { get; set; }

    public List<EmployeeFullName> emplo =new List<EmployeeFullName>();

     public int? EmpId { get; set; }

   
    }
}