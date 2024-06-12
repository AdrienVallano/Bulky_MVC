using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }
        [ForeignKey("ProduitId")]
        [ValidateNever]
        public Produit Produit { get; set; }
        [Range(0, 1000, ErrorMessage = "Merci d'entre un nombre entre 1 & 1000")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
