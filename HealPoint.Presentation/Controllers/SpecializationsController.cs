using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.Presentation.Controllers;
public class SpecializationsController : Controller
{
	#region Props
	private readonly ISpecializationService _specializationService;
	private readonly IDepartmentService _departmentService;

	#endregion

	#region Ctor
	public SpecializationsController(ISpecializationService specializationService, IDepartmentService departmentService)
	{
		_specializationService = specializationService;
		_departmentService = departmentService;
	}
	#endregion

	#region Actions

	public IActionResult Index()
	{
		return View(_specializationService.GetAllSpecializations());
	}

	[AjaxOnly]
	public IActionResult Create()
	{
		return PartialView("_Form", PopulateLookups());
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(SpecializationFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var spec = _specializationService.CreateSpecialization(model);

		return PartialView("_SpecializationRow", spec);
	}

	[AjaxOnly]
	public IActionResult Update(int id)
	{
		var specialization = _specializationService.GetSpecializationById(id);

		if (specialization is null)
			return NotFound();

		return PartialView("_Form", PopulateLookups(specialization));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Update(SpecializationFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var specializationDto = _specializationService.UpdateSpecialization(model);

		if (specializationDto == null)
			return NotFound();

		return PartialView("_SpecializationRow", specializationDto);
	}

	public IActionResult AllowedSpecializationName(SpecializationFormDto model)
	{
		return Json(_specializationService.IsSpecializationAllowed(model));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult ChangeSpecializationStatus(int id)
	{
		var isDeleted = _specializationService.UpdateSpecializationStatus(id);

		if (isDeleted is null)
			return NotFound();

		return Ok(new { isDeleted });
	}

	private SpecializationFormDto PopulateLookups(SpecializationFormDto? dto = null)
	{
		var specializationDto = dto ?? new SpecializationFormDto();
		var departments = _departmentService.GetDepartmentsLookup();

		specializationDto.DepartmentSelectList = new SelectList(departments, "Id", "Name");

		return specializationDto;
	}
	#endregion
}
