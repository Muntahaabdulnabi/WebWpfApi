using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Phone { get; set; }
        public string CustomerName => $"{FirstName} {LastName}";
    }
}
