using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class EnteteCommande
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Datecommande { get; set; }
        public DateTime DateLivraison { get; set; }
        public double TotalCommande { get; set; }

        public string? StatutCommande { get; set; }
        public string? StatutPayement { get; set; }
        public string? NumeroDeSuivi { get; set; }
        public string? Transporteur { get; set; }

        public DateTime DatePayement { get; set; }
        public DateOnly EcheancePayement { get; set; }

        public string? IdentifiantPayement { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Addresse { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string CodePostal { get; set; }
        [Required]
        public string Nom { get; set; }

    }
}
