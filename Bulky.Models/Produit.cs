using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        public string ISBN { get; set; }

        [Required]
        public string Auteur { get; set; }

        [Required]
        [DisplayName("Prix Catalogue")]
        [Range(1, 1000)]
        public double ListePrix { get; set; }

        [Required]
        [DisplayName("Prix de 1 à 50")]
        [Range(1, 1000)]
        public double Prix { get; set; }

        [Required]
        [DisplayName("Prix pour 50 et plus")]
        [Range(1, 1000)]
        public double Prix50 { get; set; }

        [Required]
        [DisplayName("Prix pour plus de 100")]
        [Range(1, 1000)]
        public double Prix100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [DisplayName("Categorie")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}