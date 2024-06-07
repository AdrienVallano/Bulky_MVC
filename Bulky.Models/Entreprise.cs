using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Entreprise
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        [DisplayName("Code Postale")]
        public string Code { get; set; }

        [DisplayName("Téléphone")]
        public string PhoneNumber { get; set; }



    }

}
