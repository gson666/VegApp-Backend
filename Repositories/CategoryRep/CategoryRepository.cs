using Backend_almog.Data;
using Backend_almog.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_almog.Repositories.CategoryRep
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Dal _context;

        public CategoryRepository(Dal context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }
        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteCategoryAsync (int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(); 
            return true;

        } 
    }
}
