using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    public class ProductsController
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {  
                var productEntity = new ProductEntity
                {
                   Id = Guid.NewGuid(),
                   Name = model.Name,
                   Description = model.Description,
                   Price = model.Price,
                   CategoyId = model.CategoyId,
                    
                };
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var product in await _context.Products.Include(x => x.Category).ToListAsync())
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoyId = product.CategoyId,
                    Price = product.Price,
                    CategoryName = product.Category.CategoryName

                });
            return new OkObjectResult(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
                return new OkObjectResult(new ProductModel { Id = productEntity.Id, Name = productEntity.Name, Description = productEntity.Description, Price = productEntity.Price, CategoyId = productEntity.CategoyId, CategoryName = productEntity.Category.CategoryName });

            return new NotFoundResult();
        }
    }
}
