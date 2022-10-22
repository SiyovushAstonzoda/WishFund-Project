using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController:Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategories());
        }
        
        public IActionResult Create()
        {
            return View( new AddCategoryDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(new AddCategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(AddCategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
}