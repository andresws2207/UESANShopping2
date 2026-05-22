using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Data;

namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await
                                _context
                                .Product
                                .Where(p => p.Id == product.Id)
                                .FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var existingProduct = await _context
                                .Product
                                .Where(p => p.Id == id)
                                .FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
