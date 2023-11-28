using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoriesAndProductsApp.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
       
        [Required]
              
        public double Price { get; set; }

        public int CategoryId { get; set; }

        
        public string Category { get; set; }

    }
}
