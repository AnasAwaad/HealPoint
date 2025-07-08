using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class DoctorSettingsController : Controller
{
	#region Props
	private readonly IServiceManager _serviceManager;
	private readonly ISpecializationService _specializationService;
	private readonly IDoctorService _doctorService;
	private readonly ISymptomService _symptomService;

	#endregion

	#region Ctor
	public DoctorSettingsController(IServiceManager serviceManager, IDoctorService doctorService, ISpecializationService specializationService, ISymptomService symptomService)
	{
		_serviceManager = serviceManager;
		_doctorService = doctorService;
		_specializationService = specializationService;
		_symptomService = symptomService;
	}
	#endregion


	#region Actions
	public IActionResult Index()
	{
		var doctor = _doctorService.GetWithSymptomsByUserId(User.GetUserId());

		if (doctor is null)
			return NotFound();

		var model = new DoctorSettingDto
		{
			DoctorId = doctor.Id,
			Specializations = _specializationService.GetActiveSpecializations(),
			AvailableServices = _serviceManager.GetActiveServices(),
			Symptoms = _symptomService.GetActiveSymptoms(),
			SelectedServiceId = doctor.ServiceId,
			SelectedSpecializationId = doctor.SpecializationId,
			SelectedSymptoms = doctor.Symptoms.Select(s => s.SymptomId).ToList(),
			OperationMode = doctor.OperationMode
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult UpdateService([FromBody] DoctorSettingDto model)
	{
		if (!model.SelectedServiceId.HasValue || model.SelectedServiceId.Equals(0))
			return BadRequest("Selected service ID cannot be zero.");

		_doctorService.ChangeService(model.DoctorId, model.SelectedServiceId.Value);
		return Ok();
	}

	[HttpPost]
	public IActionResult UpdateSpecialization([FromBody] DoctorSettingDto model)
	{
		if (!model.SelectedSpecializationId.HasValue || model.SelectedSpecializationId.Equals(0))
			return BadRequest("Please select service.");

		_doctorService.ChangeSpecialization(model.DoctorId, model.SelectedSpecializationId.Value);
		return Ok();
	}

	[HttpPost]
	public IActionResult UpdateSymptoms([FromBody] DoctorSettingDto model)
	{
		if (model.SelectedSymptoms is null || !model.SelectedSymptoms.Any())
			return BadRequest("Please select at least one symptom.");

		_doctorService.UpdateSymptoms(model.DoctorId, model.SelectedSymptoms);
		return Ok();
	}

	[HttpPost]
	public IActionResult UpdateOperationMode([FromBody] DoctorSettingDto model)
	{
		_doctorService.UpdateOperationModel(model.DoctorId, model.OperationMode);
		return Ok();
	}
	#endregion
}
