using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public IActionResult Index()
    {
        return View(_categoryService.GetAllCategories());
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _categoryService.CreateCategory(model);

        return RedirectToAction(nameof(Index));
    }
}
