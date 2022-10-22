using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CategoryService:ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext  context)
    {
        _context = context;
    }
    
    public async Task<List<GetCategoryDto>> GetCategories()
    {
        return await _context.Categories.Select(x => new GetCategoryDto()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();
    }
    
    //add category
    public async Task<GetCategoryDto> AddCategory(AddCategoryDto category)
    {
        var newCategory = new Category()
        {
            Name = category.Name,
        };
        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
        return new GetCategoryDto()
        {
            Id = newCategory.Id,
            Name = newCategory.Name,
        };
    }
    
    //update category
    public async Task<GetCategoryDto> UpdateCategory(AddCategoryDto category)
    {
        var updateCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (updateCategory == null)
        {
            return null;
        }
        updateCategory.Name = category.Name;
        await _context.SaveChangesAsync();
        return new GetCategoryDto()
        {
            Id = updateCategory.Id,
            Name = updateCategory.Name,
        };
    }
    
    //delete category
    public async Task<bool> DeleteCategory(int id)
    {
        var deleteCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (deleteCategory == null)
        {
            return false;
        }
        _context.Categories.Remove(deleteCategory);
        await _context.SaveChangesAsync();
        return true;
    }
    
    //get category by id
    public async Task<GetCategoryDto?> GetCategoryById(int id)
    {
        return await _context.Categories.Where(x => x.Id == id).Select(x => new GetCategoryDto()
        {
            Id = x.Id,
            Name = x.Name,
        }).FirstOrDefaultAsync();
    }
}