using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalog.Models
{
    [Table("Categories")]
    public class Category   
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
        public ICollection<Product>? Products {get; set;}

        public Category(){
            Products = new Collection<Product>();
        }

    }
}