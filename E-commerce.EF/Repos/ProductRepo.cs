using E_commerce.EF.Context;
using E_commerce.EF.Model;
using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public Task AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
           return await _context.Products.Include(x=>x.category).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _context.Categories.Include(x=>x.Products).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetDiscountedProductsAsync()
        {
           return await _context.Products.Where(x=>x.Discount!=null).Include(x => x.category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.Include(x => x.category).FirstOrDefaultAsync(x=>x.Id==productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _context.Products.Include(x => x.category).Where(x=> x.category.Name==category).ToListAsync();
        }

        public async Task<Product> GetProductsByRatingAsync(float minRating)
        {
            return await _context.Products.SingleOrDefaultAsync(x=>x.Rating==minRating);
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
