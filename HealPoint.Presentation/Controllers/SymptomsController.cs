using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class SymptomsController : Controller
{
	#region Props
	private readonly ISymptomService _symptomService;

	#endregion

	#region Ctor
	public SymptomsController(ISymptomService SymptomService)
	{
		_symptomService = SymptomService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View(_symptomService.GetAllSymptoms());
	}

	[AjaxOnly]
	public IActionResult Create()
	{
		return PartialView("_Form");
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(SymptomFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var Symptom = _symptomService.CreateSymptom(model);

		return PartialView("_SymptomRow", Symptom);
	}

	[AjaxOnly]
	public IActionResult Update(int id)
	{
		return PartialView("_Form", _symptomService.GetSymptomById(id));
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Update(SymptomFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var SymptomDto = _symptomService.UpdateSymptom(model);

		if (SymptomDto == null)
			return NotFound();

		return PartialView("_SymptomRow", SymptomDto);
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult ChangeSymptomStatus(int id)
	{
		(bool? isDeleted, string? lastUpdatedOn) = _symptomService.UpdateSymptomStatus(id);

		if (isDeleted is null)
			return NotFound();

		return Ok(new { isDeleted, lastUpdatedOn });
	}

	public IActionResult AllowedSymptomName(SymptomFormDto model)
	{
		return Json(_symptomService.IsSymptomAllowed(model));
	}
	#endregion
}
