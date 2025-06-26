using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.Presentation.Controllers;
public class DoctorsController : Controller
{
	#region Props
	private readonly IDoctorService _doctorService;
	private readonly ISpecializationService _specializationService;

	#endregion

	#region Ctor
	public DoctorsController(IDoctorService doctorService, ISpecializationService specializationService)
	{
		_doctorService = doctorService;
		_specializationService = specializationService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View(_doctorService.GetAll());
	}


	public IActionResult Create()
	{
		return View(PopulateDoctorDtoLookup());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateDoctorDto dto)
	{
		if (!ModelState.IsValid)
		{
			return View(PopulateDoctorDtoLookup(dto));
		}

		await _doctorService.CreateAsync(dto);

		return RedirectToAction(nameof(Index));

	}

	private CreateDoctorDto PopulateDoctorDtoLookup(CreateDoctorDto? dto = null)
	{
		var doctorDto = dto ?? new CreateDoctorDto();
		var specializations = _specializationService.GetSpecializationsLookup();

		doctorDto.SpecializationSelectList = new SelectList(specializations, "Id", "Name");

		return doctorDto;
	}
	#endregion

}
