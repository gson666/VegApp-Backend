using Backend_almog.DTO;

namespace Backend_almog.Services.CategorySer
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO?> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDTO?> CreateCategoryAsync(CategoryDTO categoryDto);
        Task<CategoryDTO?> UpdateCategoryAsync(CategoryDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
