using Domain.Dtos;

namespace Infrastructure.Services;

public interface ICategoryService 
{
    Task<List<GetCategoryDto>> GetCategories();
    Task<GetCategoryDto> AddCategory(AddCategoryDto category);
    Task<GetCategoryDto> UpdateCategory(AddCategoryDto category);
    Task<bool> DeleteCategory(int id);
    Task<GetCategoryDto?> GetCategoryById(int id);
}