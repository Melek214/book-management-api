using BookManagement.API.DTOs;

namespace BookManagement.API.Services.Interfaces
{
    //Bu interface, Category ile ilgili yapılabilecek tüm işlemleri tanımlar
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<CategoryResponseDto?> GetCategoryByIdAsync(int id);
        Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateDto dto);
        Task<CategoryResponseDto?> UpdateCategoryAsync(int id, CategoryUpdateDto dto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}