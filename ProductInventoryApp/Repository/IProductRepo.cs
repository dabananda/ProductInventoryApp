using ProductInventoryApp.Models;

namespace ProductInventoryApp.Repository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(int id);
    }
}
