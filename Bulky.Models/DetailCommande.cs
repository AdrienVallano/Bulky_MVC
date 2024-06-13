using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class DetailCommande
    {
        public int Id { get; set; }
        [Required]
        public int EnteteCommandeId { get; set; }
        [ForeignKey("EnteteCommandeId")]
        [ValidateNever]
        public EnteteCommande EnteteCommande { get; set; }

        [Required]
        public int ProduitId { get; set; }
        [ForeignKey("ProduitId")]
        [ValidateNever]
        public Produit Produit { get; set; }

        public int Count { get; set; }
        public double Prix { get; set; }

    }
}
