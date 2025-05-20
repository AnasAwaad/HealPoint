using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
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

    [AjaxOnly]
    public IActionResult Create()
    {
        var categoryDto = new CategoryFormDto
        {
            ParentCategoryOptions = _categoryService.GetParentCategorySelectList()
        };
        return PartialView("_Form", categoryDto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CategoryFormDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var category = _categoryService.CreateCategory(model);

        return PartialView("_CategoryRow", category);
    }

    [AjaxOnly]
    public IActionResult Update(int id)
    {
        var category = _categoryService.GetCategoryById(id);

        return PartialView("_Form", category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(CategoryFormDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var categoryDto = _categoryService.UpdateCategory(model);

        if (categoryDto == null)
            return NotFound();

        return PartialView("_CategoryRow", categoryDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeStatus(int id)
    {
        var lastUpdatedOn = _categoryService.ChangeStatus(id);

        if (lastUpdatedOn is null)
            return NotFound();

        return Ok(lastUpdatedOn);
    }

}
