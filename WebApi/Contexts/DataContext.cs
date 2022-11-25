using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }


    }
}
