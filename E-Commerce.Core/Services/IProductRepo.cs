using E_commerce.EF.Model;
using E_Commerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

  
        Task<Product> GetProductByIdAsync(int productId);

      
        Task AddProductAsync(Product product);

      
        Task UpdateProductAsync(Product product);

     
        Task DeleteProductAsync(int productId);


        Task<IEnumerable<Category>> GetCategoryAsync();

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);

  
        Task<Product> GetProductsByRatingAsync(float minRating);

        
        Task<IEnumerable<Product>> GetDiscountedProductsAsync();



    }
}
