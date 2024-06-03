using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string? Nom { get; set; }
        public string? Adresse { get; set; }    
        public string? Ville { get; set; }  
        public int CodePostale { get; set; }
    }
}
