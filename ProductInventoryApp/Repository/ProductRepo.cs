﻿using Microsoft.EntityFrameworkCore;
using ProductInventoryApp.Data;
using ProductInventoryApp.Models;

namespace ProductInventoryApp.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var type = product.GetType();
            var prop = type.GetProperty("InStock");
            prop?.SetValue(product, product.Quantity > 0);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(string? searchQuery)
        {
            if (searchQuery == null)
            {
                return await _context.Products.Include(p => p.Category).ToListAsync();
            }
            var query = _context.Products.Include(p => p.Category).AsQueryable();
            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                query = query.Where(p => p.Name.Contains(searchQuery) || p.Category.Name.Contains(searchQuery));
            }
            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Manufacturer = product.Manufacturer;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Unit = product.Unit;
                existingProduct.ManufacturerDate = product.ManufacturerDate;
                existingProduct.ExpiryDate = product.ExpiryDate;

                if (product.Image != null)
                {
                    existingProduct.Image = product.Image;
                }

                var type = existingProduct.GetType();
                var prop = type.GetProperty("InStock");
                prop?.SetValue(existingProduct, existingProduct.Quantity > 0);

                await _context.SaveChangesAsync();
                return existingProduct;
            }
            return null;
        }
    }
}
