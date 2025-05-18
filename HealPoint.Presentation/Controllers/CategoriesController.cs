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
		return View("Form");
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(CategoryFormDto model)
	{
		if (!ModelState.IsValid)
			return View(model);

		_categoryService.CreateCategory(model);

		return RedirectToAction(nameof(Index));
	}


	public IActionResult Update(int id)
	{
		var category = _categoryService.GetCategoryById(id);

		return View("Form", category);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Update(CategoryFormDto model)
	{
		if (!ModelState.IsValid)
			return View(model);

		bool isUpdated = _categoryService.UpdateCategory(model);

		if (!isUpdated)
			return NotFound();

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult ChangeStatus(int id)
	{
		var isUpdated = _categoryService.ChangeStatus(id);

		if (!isUpdated)
			return NotFound();


		return Ok(DateTime.Now.ToString());
	}
}
