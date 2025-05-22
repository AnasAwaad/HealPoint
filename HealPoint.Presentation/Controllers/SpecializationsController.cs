using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class SpecializationsController : Controller
{
	private readonly ISpecializationService _specializationService;

	public SpecializationsController(ISpecializationService specializationService)
	{
		_specializationService = specializationService;
	}

	public IActionResult Index()
	{
		return View(_specializationService.GetAllSpecializations());
	}

	[AjaxOnly]
	public IActionResult Create()
	{
		var specDto = new SpecializationFormDto
		{
			CategoryOptions = _specializationService.GetCategorySelectList()
		};
		return PartialView("_Form", specDto);
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
}
