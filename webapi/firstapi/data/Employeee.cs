using System;
using System.Collections.Generic;

namespace firstapi.data
{
    public partial class Employeee
    {
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? ContactNo { get; set; }
        public string? HomeAddress { get; set; }
        public string? WorkLocation { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
