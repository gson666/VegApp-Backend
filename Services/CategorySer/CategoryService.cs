using AutoMapper;
using Backend_almog.DTO;
using Backend_almog.Models;
using Backend_almog.Repositories.CategoryRep;

namespace Backend_almog.Services.CategorySer
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO?> CreateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryRepository.CreateCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(newCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
           var category = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(category);  
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }
    }
}
