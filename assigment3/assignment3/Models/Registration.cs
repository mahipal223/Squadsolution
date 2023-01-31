using System;
using System.Collections.Generic;

namespace assignment3.Models
{
    public partial class Registration
    {
        public int RecId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime? LastUpadated { get; set; }
        public DateTime? Endeffdt { get; set; }
    }
}
