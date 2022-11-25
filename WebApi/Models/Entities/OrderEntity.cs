using Microsoft.VisualBasic;

namespace WebApi.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DueDate DueDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public decimal TotalPrice { get; set; } 
        public ICollection<ProductEntity> Products { get; set; }
    }
}
