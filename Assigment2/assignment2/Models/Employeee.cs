using System;
using System.Collections.Generic;

namespace assignment2.Models;

public partial class Employeee
{
    public int EmpId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? ContactNo { get; set; }

    public string? HomeAddress { get; set; }

    public string? WorkLocation { get; set; }

    public virtual ICollection<Hr> Hrs { get; } = new List<Hr>();
}
