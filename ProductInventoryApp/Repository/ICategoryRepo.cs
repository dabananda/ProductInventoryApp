using ProductInventoryApp.Models;

namespace ProductInventoryApp.Repository
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);
    }
}
