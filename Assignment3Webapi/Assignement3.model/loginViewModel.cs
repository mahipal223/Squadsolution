using System.ComponentModel.DataAnnotations;

namespace Assignement3.model;

public class loginViewModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
