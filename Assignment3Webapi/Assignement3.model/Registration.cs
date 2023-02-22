using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace assignment3.Models
{
    public partial class Registration
    {
        public int RecId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string ContactNo { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime? LastUpadated { get; set; }
        public DateTime? Endeffdt { get; set; }
    }
}
