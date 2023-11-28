using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CategoriesAndProductsApp.Models
{
    public class Category
    {
        [Key] 
        public int ID { get; set; }
        [Required] 
        public string Name { get; set; }

        [DisplayName("Display Name")]

        [Range(1, 100, ErrorMessage = "Should be in range 1 to 100.")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
