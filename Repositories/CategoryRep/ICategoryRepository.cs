using Backend_almog.Models;
namespace Backend_almog.Repositories.CategoryRep
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<Category?> CreateCategoryAsync(Category category);
        Task<Category?> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
