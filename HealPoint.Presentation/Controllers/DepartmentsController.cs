using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class DepartmentsController : Controller
{
	#region Props
	private readonly IDepartmentService _departmentService;

	#endregion

	#region Ctor
	public DepartmentsController(IDepartmentService DepartmentService)
	{
		_departmentService = DepartmentService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View(_departmentService.GetAllDepartments());
	}

	[AjaxOnly]
	public IActionResult Create()
	{
		return PartialView("_Form");
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(DepartmentFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var Department = _departmentService.CreateDepartment(model);

		return PartialView("_DepartmentRow", Department);
	}

	[AjaxOnly]
	public IActionResult Update(int id)
	{
		return PartialView("_Form", _departmentService.GetDepartmentById(id));
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Update(DepartmentFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var DepartmentDto = _departmentService.UpdateDepartment(model);

		if (DepartmentDto == null)
			return NotFound();

		return PartialView("_DepartmentRow", DepartmentDto);
	}
	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult UpdateFeaturedStatus(int id)
	{
		var lastUpdatedOn = _departmentService.UpdateFeaturedStatus(id);

		if (lastUpdatedOn is null)
			return NotFound();

		return Ok(lastUpdatedOn);
	}
	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult ChangeDepartmentStatus(int id)
	{
		var lastUpdatedOn = _departmentService.UpdateDepartmentStatus(id);

		if (lastUpdatedOn is null)
			return NotFound();

		return Ok(lastUpdatedOn);
	}
	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteDepartment(int id)
	{
		var isDeleted = _departmentService.DeleteDepartment(id);

		if (!isDeleted)
			return BadRequest();

		return Ok();
	}

	public IActionResult AllowedDepartmentName(DepartmentFormDto model)
	{
		return Json(_departmentService.IsDepartmentAllowed(model));
	}
	#endregion
}
