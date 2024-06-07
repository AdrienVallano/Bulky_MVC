using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Nom { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? CodePostal { get; set; }
        public int? EntrepriseId { get; set; }

        [ForeignKey("EntrepriseId")]
        [ValidateNever]
        public Entreprise Entreprise { get; set; }

    }
}
