﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Models;

namespace MunApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
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
            return BadRequest();
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
                    Price = product.Price,
                    CategoryId = product.CategoyId,
                    CategoryName = product.Category.CategoryName
                });
            return new OkObjectResult(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
                return new OkObjectResult(new ProductModel { Id = productEntity.Id, Name = productEntity.Name, Description = productEntity.Description, Price = productEntity.Price });

            return new NotFoundResult();
        }
    }
}

