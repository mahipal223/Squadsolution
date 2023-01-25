using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mymvcproject.Models
{
    public class Registration
    {
        [Key]
        public int id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string email { get; set; }  
        [Required] 
        public string password { get; set; }
        [Required] 
        public int phoneno { get; set; }    
    }
}