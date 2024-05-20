using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulky_Razor_Test.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be betwenn 1-100")]
        public int DisplayOrder { get; set; }
    }
}
