using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; } 
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
