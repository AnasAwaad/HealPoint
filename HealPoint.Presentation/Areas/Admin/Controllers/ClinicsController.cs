using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Consts;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.Presentation.Areas.Admin.Controllers;
[Authorize(Roles = AppRoles.Admin)]
[Area("Admin")]
public class ClinicsController : Controller
{
	#region Props
	private readonly IClinicService _clinicService;
	private readonly ISpecializationService _specializationService;
	private readonly IClinicSessionService _clinicSessionService;
	#endregion

	#region Ctor

	public ClinicsController(IClinicService clinicService, ISpecializationService specializationService, IClinicSessionService clinicSessionService)
	{
		_clinicService = clinicService;
		_specializationService = specializationService;
		_clinicSessionService = clinicSessionService;
	}
	#endregion

	#region Actions

	#region Clinics Actions
	public IActionResult Index()
	{
		return View(_clinicService.GetAllClinics());
	}


	public IActionResult Create()
	{
		return View(PopulateLookups());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateClinicDto clinic)
	{
		if (!ModelState.IsValid)
			return View(PopulateLookups());

		await _clinicService.CreateClinicAsync(clinic);

		return RedirectToAction(nameof(Index));
	}

	public IActionResult Update(int id)
	{

		var clinic = _clinicService.GetClinicById(id);

		if (clinic is null)
			return NotFound();

		//clinic.SpecializationOptions = _specializationService.GetSpecializationsLookup();

		return View(clinic);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(UpdateClinicDto clinic)
	{
		if (!ModelState.IsValid)
			return View(PopulateLookups());

		await _clinicService.UpdateClinicAsync(clinic);

		return RedirectToAction(nameof(Index));
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteClinic(int id)
	{
		var isDeleted = _clinicService.DeleteClinic(id);

		if (!isDeleted)
			return BadRequest();

		return Ok();
	}

	private CreateClinicDto PopulateLookups(CreateClinicDto? dto = null)
	{
		var clinicDto = dto ?? new CreateClinicDto();
		var specializations = _specializationService.GetSpecializationsLookup();

		clinicDto.SpecializationSelectList = new SelectList(specializations, "Id", "Name");

		return clinicDto;
	}
	#endregion

	#region ClinicSessions Actions

	[AjaxOnly]
	public IActionResult GetClinicSessions(int clinicId)
	{
		return PartialView("_ClinicSessionsForm", _clinicSessionService.GetSessionsByClinicId(clinicId));
	}
	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult SaveClinicSessions([FromBody] List<ClinicSessionDto> clinicSessions)
	{
		if (clinicSessions == null || !clinicSessions.Any())
			return BadRequest("No clinic sessions data received.");

		_clinicSessionService.SaveClinicSessions(clinicSessions);
		return Ok();
	}

	#endregion

	#endregion
}
