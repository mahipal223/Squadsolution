using System.ComponentModel.DataAnnotations;

namespace trialMvcProject.Models;

public class Registration
{
    [Key]
    public int userid { get; set; }
    [Required]
    public string userEmail { get; set; }
    [Required]
    public string userPassword { get; set; }    
    
}


