using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class ClinicsController : Controller
{
	private readonly IClinicService _clinicService;
	private readonly ISpecializationService _specializationService;

	public ClinicsController(IClinicService clinicService, ISpecializationService specializationService)
	{
		_clinicService = clinicService;
		_specializationService = specializationService;
	}

	public IActionResult Index()
	{
		return View(_clinicService.GetAllClinics());
	}


	public IActionResult Create()
	{
		var model = new CreateClinicDto
		{
			SpecializationOptions = _specializationService.GetSpecializationSelectList()
		};
		return View(model);
	}

	[HttpPost]
	public IActionResult Create(CreateClinicDto clinic)
	{
		if (!ModelState.IsValid)
		{
			var model = new CreateClinicDto
			{
				SpecializationOptions = _specializationService.GetSpecializationSelectList()
			};
			return View(model);
		}

		_clinicService.CreateClinic(clinic);

		return RedirectToAction(nameof(Index));
	}
}
