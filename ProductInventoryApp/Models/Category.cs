using System.ComponentModel.DataAnnotations;

namespace ProductInventoryApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
