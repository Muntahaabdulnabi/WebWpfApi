using Microsoft.VisualBasic;

namespace WebApi.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DueDate DueDate { get; set; }
        public string StreetName { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal TotalPrice { get; set; } 
        public ICollection<ProductEntity> Products { get; set; }
    }
}
