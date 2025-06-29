using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.Presentation.Controllers;
public class DoctorsController : Controller
{
	#region Props
	private readonly IDoctorService _doctorService;
	private readonly ISpecializationService _specializationService;
	private readonly IDepartmentService _departmentService;
	private readonly IAuthService _authService;

	#endregion

	#region Ctor
	public DoctorsController(IDoctorService doctorService, ISpecializationService specializationService, IDepartmentService departmentService, IAuthService authService)
	{
		_doctorService = doctorService;
		_specializationService = specializationService;
		_departmentService = departmentService;
		_authService = authService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View(_doctorService.GetAll());
	}


	public IActionResult Create()
	{
		return View("Form", PopulateLookups());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(DoctorFormDto dto)
	{
		if (!ModelState.IsValid)
			return View(PopulateLookups(dto));

		await _doctorService.CreateAsync(dto);

		return RedirectToAction(nameof(Index));

	}

	public IActionResult Update(int id)
	{
		var doctorDto = _doctorService.GetById(id);

		if (doctorDto == null)
			return NotFound();

		return View("Form", PopulateLookups(doctorDto));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(DoctorFormDto dto)
	{
		if (!ModelState.IsValid)
			return View("Form", PopulateLookups(dto));

		await _doctorService.UpdateAsync(dto);
		return RedirectToAction(nameof(Index));
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> UpdateStatus(int id)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		await _doctorService.ToggleDoctorStatusAsync(id);
		return Ok();
	}

	[HttpGet]
	[AjaxOnly]
	public async Task<IActionResult> ResetPassword(string id)
	{
		var user = await _authService.GetUsersByIdAsync(id);

		if (user is null)
			return BadRequest();

		return PartialView("_ResetPassword", new UserResetPasswordDto() { Id = id });
	}


	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> ResetPassword(UserResetPasswordDto dto)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		(bool isSucceeded, string? errors) = await _authService.ResetPasswordAsync(dto.Id, dto.Password);

		if (!isSucceeded)
			return BadRequest(errors);

		return Ok();

	}


	public IActionResult IsAllowedMobileNumber(DoctorFormDto dto)
	{
		var isAllowed = _doctorService.IsAllowedMobileNumber(dto.PhoneNumber, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedContactEmail(DoctorFormDto dto)
	{
		var isAllowed = _doctorService.IsAllowedContactEmail(dto.ContactEmail, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedEmergencyContactPhone(DoctorFormDto dto)
	{
		var isAllowed = _doctorService.IsAllowedEmergencyContactPhone(dto.EmergencyContactPhone, dto.Id);
		return Json(isAllowed);
	}
	public IActionResult IsAllowedUserName(DoctorFormDto dto)
	{
		var isAllowed = _doctorService.IsAllowedUserName(dto.UserName, dto.Id);
		return Json(isAllowed);
	}

	public IActionResult IsAllowedEmail(DoctorFormDto dto)
	{
		var isAllowed = _doctorService.IsAllowedEmail(dto.Email, dto.Id);
		return Json(isAllowed);
	}

	private DoctorFormDto PopulateLookups(DoctorFormDto? dto = null)
	{
		var doctorDto = dto ?? new DoctorFormDto();
		var specializations = _specializationService.GetSpecializationsLookup();
		var departments = _departmentService.GetDepartmentsLookup();

		doctorDto.SpecializationSelectList = new SelectList(specializations, "Id", "Name");
		doctorDto.DepartmentSelectList = new SelectList(departments, "Id", "Name");
		return doctorDto;
	}

	#endregion

}
