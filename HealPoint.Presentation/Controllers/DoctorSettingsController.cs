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

	#endregion

	#region Ctor
	public DoctorSettingsController(IServiceManager serviceManager, IDoctorService doctorService, ISpecializationService specializationService)
	{
		_serviceManager = serviceManager;
		_doctorService = doctorService;
		_specializationService = specializationService;
	}
	#endregion


	#region Actions
	public IActionResult Index()
	{
		var doctor = _doctorService.GetByUserId(User.GetUserId());

		if (doctor is null)
			return NotFound();

		var model = new DoctorSettingDto
		{
			DoctorId = doctor.Id,
			Specializations = _specializationService.GetActiveServicesForDoctor(),
			AvailableServices = _serviceManager.GetActiveServicesForDoctor(),
			SelectedServiceId = doctor.ServiceId,
			SelectedSpecializationId = doctor.SpecializationId
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
	#endregion
}
