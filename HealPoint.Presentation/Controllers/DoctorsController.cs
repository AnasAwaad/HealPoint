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
		return View(PopulateLookups());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateDoctorDto dto)
	{
		if (!ModelState.IsValid)
			return View(PopulateLookups(dto));

		await _doctorService.CreateAsync(dto);

		return RedirectToAction(nameof(Index));

	}
	public IActionResult IsAllowedMobileNumber(CreateDoctorDto dto)
	{
		var isAllowed = _doctorService.IsAllowedMobileNumber(dto.PhoneNumber, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedContactEmail(CreateDoctorDto dto)
	{
		var isAllowed = _doctorService.IsAllowedContactEmail(dto.ContactEmail, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedEmergencyContactPhone(CreateDoctorDto dto)
	{
		var isAllowed = _doctorService.IsAllowedEmergencyContactPhone(dto.EmergencyContactPhone, dto.Id);
		return Json(isAllowed);
	}
	public IActionResult IsAllowedUserName(CreateDoctorDto dto)
	{
		var isAllowed = _doctorService.IsAllowedUserName(dto.UserName, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedEmail(CreateDoctorDto dto)
	{
		var isAllowed = _doctorService.IsAllowedEmail(dto.Email, dto.Id);
		return Json(isAllowed);
	}

	private CreateDoctorDto PopulateLookups(CreateDoctorDto? dto = null)
	{
		var doctorDto = dto ?? new CreateDoctorDto();
		var specializations = _specializationService.GetSpecializationsLookup();

		doctorDto.SpecializationSelectList = new SelectList(specializations, "Id", "Name");

		return doctorDto;
	}

	#endregion

}
