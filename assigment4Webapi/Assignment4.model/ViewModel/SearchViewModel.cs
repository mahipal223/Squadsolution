using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment4.model.ViewModel
{
    public class SearchViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HaveKnow { get; set; }
        public int? DepartmentId { get; set; }
        public Nullable<DateTime> JoiningDate { get; set; }

        public Nullable<DateTime> JoiningDate1 { get; set; }

    }
}