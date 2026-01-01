using BookManagement.API.DTOs;
using BookManagement.API.Models;
using BookManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(ApiResponse<List<CategoryResponseDto>>.Ok(result, "Kategoriler listelendi"));
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(ApiResponse<string>.Fail("Kategori bulunamadı"));

            return Ok(ApiResponse<CategoryResponseDto>.Ok(category, "Kategori getirildi"));
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(dto);
            return Ok(ApiResponse<CategoryResponseDto>.Ok(createdCategory, "Kategori oluşturuldu"));
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto dto)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, dto);

            if (updatedCategory == null)
                return NotFound(ApiResponse<string>.Fail("Kategori bulunamadı"));

            return Ok(ApiResponse<CategoryResponseDto>.Ok(updatedCategory, "Kategori güncellendi"));
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<string>.Fail("Kategori bulunamadı"));

            return Ok(ApiResponse<string>.Ok("Kategori silindi"));
        }
    }
}
