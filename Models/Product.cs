using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalog.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public float Stock { get; set; }      
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}