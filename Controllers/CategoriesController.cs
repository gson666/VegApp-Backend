using Backend_almog.DTO;
using Backend_almog.Services.CategorySer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_almog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCateogry(CategoryDTO category)
        {
            var newCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(CreateCateogry), newCategory);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.CategoryId) return BadRequest();

            var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryDTO);
            if(updatedCategory == null) return NotFound();

            return Ok(updatedCategory);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(id);
            if(!isDeleted) return NotFound();

            return NoContent();
        }

    }
}
