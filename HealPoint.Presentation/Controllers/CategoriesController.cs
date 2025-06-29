﻿using HealPoint.BusinessLogic.Contracts;
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

    [AjaxOnly]
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
        category.ParentCategoryOptions = _categoryService.GetParentCategorySelectList();

        return PartialView("_Form", category);
    }

    [AjaxOnly]
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
    [AjaxOnly]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateFeaturedStatus(int id)
    {
        var lastUpdatedOn = _categoryService.UpdateFeaturedStatus(id);

        if (lastUpdatedOn is null)
            return NotFound();

        return Ok(lastUpdatedOn);
    }
    [AjaxOnly]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeCategoryStatus(int id)
    {
        var lastUpdatedOn = _categoryService.UpdateCategoryStatus(id);

        if (lastUpdatedOn is null)
            return NotFound();

        return Ok(lastUpdatedOn);
    }
    [AjaxOnly]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategory(int id)
    {
        var isDeleted = _categoryService.DeleteCategory(id);

        if (!isDeleted)
            return BadRequest();

        return Ok();
    }

    public IActionResult AllowedCategoryName(CategoryFormDto model)
    {
        return Json(_categoryService.IsCategoryAllowed(model));
    }
}
